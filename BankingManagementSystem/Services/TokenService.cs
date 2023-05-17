using System;
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

        public string BuildToken(string key, string issuer, string audience, UserDto user)
        {
            var claimNames = user.Roles.SelectMany(r => r.RoleClaims)
                .Select(rc => rc.ClaimView).ToHashSet();
            user.Claims.ForEach(uc => claimNames.Add(uc.ClaimView));
            user.Roles.ForEach(r => claimNames.Add(r.Name));
            var claims = claimNames.Select(c => new Claim(ClaimTypes.Role, c)).ToList();
            claims.AddRange(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid,Guid.NewGuid().ToString())
            });

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
                expires: DateTime.Now.AddMinutes(_jwtOptions.ExpirationTime), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public bool ValidateToken(string key, string issuer, string audience, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

