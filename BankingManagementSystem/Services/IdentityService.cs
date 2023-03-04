using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace BankingManagementSystem.Services
{
	public class IdentityService : IIdentityService
	{
        private readonly BankingManagementSystemContext _context;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICryptographyService _cryptographyService;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(BankingManagementSystemContext context,
            ITokenService tokenService,
            IHttpContextAccessor httpContextAccessor,
            ICryptographyService cryptographyService,
            IMapper mapper,
            IOptions<JwtSettings> jwtSettings)
		{
            _context = context;
            _tokenService = tokenService;
            _httpContext = httpContextAccessor;
            _mapper = mapper;
            _cryptographyService = cryptographyService;
            _jwtSettings = jwtSettings?.Value;
		}

        public Task<BmsResponse> Login(string login, string password)
        {
            var response = new BmsResponse();
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                response.ApplicationError = "Login or password are empty.";
                return Task.FromResult(response);

            }
            var passwordHash = _cryptographyService.GetPasswordHash(password);
            var validUser = _context.Users.Where(x => x.NormalizedEmail == login.ToUpper() && x.PasswordHash == passwordHash).ProjectTo<BmsUserProjection>(_mapper.ConfigurationProvider).SingleOrDefault();

            if (validUser != null)
            {
                var generatedToken = _tokenService.BuildToken(_jwtSettings.Key, _jwtSettings.Issuer, _jwtSettings.Audience, validUser);
                if (generatedToken != null)
                { 
                    _httpContext.HttpContext.Response.Cookies.Append("Token", generatedToken);
                    return Task.FromResult(response);
                }
                else
                {
                    response.ApplicationError = "Token not generated";
                }
            }
            else
            {
                response.ApplicationError = $"User '{login}' not found.";
                
            }
            return Task.FromResult(response);
        }

        public Task LogOut()
        {
            _httpContext.HttpContext.Response.Cookies.Delete("Token");
            return Task.CompletedTask;
        }

        public Task RefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}

