using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BankingManagementSystem.Dto;
using BankingManagementSystem.IdentityDomain;
using BankingManagementSystem.Services;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BankingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [IgnoreAntiforgeryToken]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IAntiforgery _antiForgery;
        private string Token { get; }
        private string XsrfToken { get; }

        public IdentityController(IIdentityService identityService, 
            IAntiforgery antiForgery, 
            IOptions<JwtSettings> jwtSettings,
            IOptions<CsrfSettings> csrfSettings)
        {
            _identityService = identityService;
            _antiForgery = antiForgery;
            Token = jwtSettings.Value.JwtName;
            XsrfToken = csrfSettings.Value.XsrfToken;

        }

        [HttpPost]
        public async Task<BmsResponse> Login(SignInDto model)
        {
            var response = await _identityService.Login(model.Username, model.Password);
            if (!string.IsNullOrWhiteSpace(response.AccessToken))
            {
                HttpContext.Response.Cookies.Append(Token, response.AccessToken);
                _antiForgery.GetAndStoreTokens(HttpContext);
            }
            
            return response;
        }

        [HttpGet]
        public async Task<BmsResponse> LogOut()
        {
            HttpContext.Response.Cookies.Delete(Token);
            HttpContext.Response.Cookies.Delete(XsrfToken);
            var userClaimEmail = HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email);
            return await _identityService.Logout(userClaimEmail?.Value);
        }

        [HttpGet]
        public async Task<IActionResult> RefreshToken()
        {
            var accessToken = HttpContext.Request.Cookies[Token];
            
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized();
            }
            
            var userClaimEmail = HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email);
            if (string.IsNullOrEmpty(userClaimEmail?.Value))
            {
                return Unauthorized();
            }
            
            var response = await _identityService.RefreshToken(userClaimEmail.Value);
            if (string.IsNullOrEmpty(response.AccessToken))
            {
                return Unauthorized();
            }
            
            HttpContext.Response.Cookies.Append(Token, response.AccessToken);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task<UserProfileResponse> UserProfile()
        {
        
            var userClaimEmail = HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email);
            return _identityService.UserProfile(userClaimEmail?.Value);
        }
    }
}

