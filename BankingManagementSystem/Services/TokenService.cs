using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BankingManagementSystem.Services
{
	public class TokenService : ITokenService
	{
        private readonly JwtSettings _jwtOptions;

        public TokenService(IOptions<JwtSettings> jwtOptions)
        {
            _jwtOptions = jwtOptions?.Value;
        }

        public string BuildAccessToken(UserDto user)
        {
            var expirationTime = DateTime.Now.AddMinutes(_jwtOptions.ExpirationTime);
            var claimNames = user.Roles.SelectMany(r => r.RoleClaims)
                .Select(rc => rc.ClaimView).ToHashSet();
            user.Claims.ForEach(uc => claimNames.Add(uc.ClaimView));
            user.Roles.ForEach(r => claimNames.Add(r.Name));
            var claims = claimNames.Select(c => new Claim(ClaimTypes.Role, c)).ToList();
            claims.AddRange(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Expiration, expirationTime.ToString(CultureInfo.InvariantCulture))
            });

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, claims,
                expires: expirationTime, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public string BuildRefreshToken(UserDto user)
        {
            var expirationTime = DateTime.Now.AddMinutes(_jwtOptions.RefreshExpirationTime);
            var claims = new List<Claim>(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Expiration, expirationTime.ToString(CultureInfo.InvariantCulture))
            });

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, claims,
                expires: expirationTime, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public SecurityToken ReadToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadToken(token);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                    CreateTokenValidationParameter(), out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        public bool TokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                    CreateTokenValidationParameter(), out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }

            return false;
        }

        private TokenValidationParameters CreateTokenValidationParameter()
        {
            var mySecret = Encoding.UTF8.GetBytes(_jwtOptions.Key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = mySecurityKey
            };
        }
    }
}

