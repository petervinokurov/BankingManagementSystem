using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BankingManagmentSystem.Services
{
	public class IdentityService : IIdentityService
	{
        private readonly BankingManagmentSystemContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICryptographyService _cryptographyService;
        private readonly IMapper _mapper;
        private readonly ILogger<IdentityService> _logger;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(BankingManagmentSystemContext context,
            ITokenService tokenService,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            ICryptographyService cryptographyService,
            IMapper mapper,
            ILogger<IdentityService> logger,
            IOptions<JwtSettings> jwtSettings)
		{
            _context = context;
            _tokenService = tokenService;
            _configuration = configuration;
            _httpContext = httpContextAccessor;
            _mapper = mapper;
            _cryptographyService = cryptographyService;
            _logger = logger;
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

