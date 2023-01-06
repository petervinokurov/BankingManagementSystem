using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Entities;
using BankingManagmentSystem.Projections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

        public IdentityService(BankingManagmentSystemContext context,
            ITokenService tokenService,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            ICryptographyService cryptographyService,
            IMapper mapper,
            ILogger<IdentityService> logger)
		{
            _context = context;
            _tokenService = tokenService;
            _configuration = configuration;
            _httpContext = httpContextAccessor;
            _mapper = mapper;
            _cryptographyService = cryptographyService;
            _logger = logger;
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
            var validUser = _context.Users.Where(x => x.NormalizedEmail == login.ToUpper() && x.PasswordHash == passwordHash).ProjectTo<BmcUserProjection>(_mapper.ConfigurationProvider).SingleOrDefault();

            if (validUser != null)
            {
                var generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null)
                {
                    
                    _httpContext.HttpContext.Session.SetString("Token", generatedToken);
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

        public Task LogOut(string login)
        {
            throw new NotImplementedException();
        }

        public Task RefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}

