using System.Threading.Tasks;
using BankingManagementSystem.Dto;
using BankingManagementSystem.IdentityDomain;

namespace BankingManagementSystem.Services
{
    public interface IIdentityService
    {
        Task<LoginResponse> Login(string login, string passwordHash);
        Task<BmsResponse> Logout(string userEmail);
        Task<RefreshTokenResponse> RefreshToken(string userEmail);
        Task<UserProfileResponse> UserProfile(string userEmail);
    }
}

