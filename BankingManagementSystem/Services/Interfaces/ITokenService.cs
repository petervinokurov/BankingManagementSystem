namespace BankingManagementSystem.Services
{
    public interface ITokenService
    {
        string BuildAccessToken(UserDto user);
        string BuildRefreshToken(UserDto user);
        bool ValidateToken(string token);
    }
}

