using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagmentSystem.Entities;
using BankingManagmentSystem.Projections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

        public IdentityService(BankingManagmentSystemContext context,
            ITokenService tokenService,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            ICryptographyService cryptographyService,
            IMapper mapper)
		{
            _context = context;
            _tokenService = tokenService;
            _configuration = configuration;
            _httpContext = httpContextAccessor;
            _mapper = mapper;
            _cryptographyService = cryptographyService;
		}

        public Task Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return Task.CompletedTask;

                //return (RedirectToAction("Error"));
            }
            //IActionResult response = Unauthorized();
            var passwordHash = _cryptographyService.GetPasswordHash(password);
            var validUser = _context.Users.Where(x => x.UserName == login && x.PasswordHash == passwordHash).ProjectTo<BmcUserProjection>(_mapper.ConfigurationProvider).SingleOrDefault();

            if (validUser != null)
            {
                var generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null)
                {
                    
                    _httpContext.HttpContext.Session.SetString("Token", generatedToken);
                    return Task.CompletedTask;
                }
                else
                {
                    return Task.CompletedTask;
                }
            }
            else
            {
                return Task.CompletedTask;
            }
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

