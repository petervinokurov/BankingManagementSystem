using Microsoft.IdentityModel.Tokens;

namespace BankingManagementSystem.Services
{
    public interface ITokenService
    {
        string BuildAccessToken(UserDto user);
        string BuildRefreshToken(UserDto user);
        bool ValidateToken(string token);
        bool TokenExpired(string token);
        SecurityToken ReadToken(string token);
    }
}

