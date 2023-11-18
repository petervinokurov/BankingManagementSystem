using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Entities;
using BankingManagementSystem.IdentityDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BankingManagementSystem.Services
{
	public class IdentityService : IIdentityService
	{
        private readonly BankingManagementSystemContext _context;
        private readonly ITokenService _tokenService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;
        const string RefreshTokenName = "RefreshToken";

        public IdentityService(BankingManagementSystemContext context,
            IOptions<JwtSettings> jwtSettings,
            ITokenService tokenService,
            ICryptographyService cryptographyService,
            IMapper mapper)
		{
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
            _cryptographyService = cryptographyService;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<BmsResponse> Logout(string userEmail)
        {
            var response = new BmsResponse();
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                response.ApplicationError = "Token structure invalid.";
                return await Task.FromResult(response);
            }

            var validUser = await _context.Users.Where(x => x.NormalizedEmail == userEmail.ToUpper())
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            var refreshToken = await _context.UserTokens.SingleOrDefaultAsync(x => x.UserId == validUser.Id);
            if (refreshToken == null) return await Task.FromResult(response);
            _context.UserTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();

            return await Task.FromResult(response);
        }
        
        public async Task<LoginResponse> Login(string login, string password)
        {
            var response = new LoginResponse();
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                response.ApplicationError = "Login or password are empty.";
                return await Task.FromResult(response);
            }
            var passwordHash = _cryptographyService.GetPasswordHash(password);
            var validUser = await _context.Users
                .Include(u => u.Roles)
                .Include(u => u.Claims)
                .Where(x => x.NormalizedEmail == login.ToUpper() && x.PasswordHash == passwordHash)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            if (validUser != null)
            {
                var accessToken = _tokenService.BuildAccessToken(validUser);

                var refreshToken = await _context.UserTokens.SingleOrDefaultAsync(x => x.UserId == validUser.Id);
                if (refreshToken == null)
                {
                    var newRefreshToken = _tokenService.BuildRefreshToken(validUser);
                    _context.UserTokens.Add(new IdentityUserToken<Guid>
                    {
                        UserId = validUser.Id,
                        Value = newRefreshToken,
                        LoginProvider = _jwtSettings.Provider,
                        Name = RefreshTokenName
                    });
                    await _context.SaveChangesAsync();
                }
                else if (!_tokenService.ValidateToken(refreshToken.Value))
                {
                    refreshToken.Value = _tokenService.BuildRefreshToken(validUser);
                    await _context.SaveChangesAsync();
                }

                response.AccessToken = accessToken;
            }
            else
            {
                response.ApplicationError = $"User '{login}' not found.";
            }
            return await Task.FromResult(response);
        }

        public async Task<RefreshTokenResponse> RefreshToken(string userEmail)
        {
            var response = new RefreshTokenResponse();

            var validUser = await _context.Users
                .Where(x => x.NormalizedEmail == userEmail.ToUpper())
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            var savedToken = await _context.UserTokens.SingleOrDefaultAsync(x => x.UserId == validUser.Id);
            if (_tokenService.ValidateToken(savedToken?.Value))
            {
                response.AccessToken = _tokenService.BuildAccessToken(validUser);
            }
            
            return await Task.FromResult(response);
        }

        public async Task<UserProfileResponse> UserProfile(string userEmail)
        {
            var response = new UserProfileResponse();
            
            if (string.IsNullOrEmpty(userEmail))
            {
                response.ApplicationError = "Token structure invalid.";
                return response;
            }

            var userProfileDto = await _context.Users
                .Where(x => x.NormalizedEmail == userEmail.ToUpper())
                .ProjectTo<UserProfileDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            response.User = userProfileDto;
            
            return response;
        }
    }
}

