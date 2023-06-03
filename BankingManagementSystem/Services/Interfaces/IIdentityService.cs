using System.Threading.Tasks;
using BankingManagementSystem.Dto;
using BankingManagementSystem.IdentityDomain;

namespace BankingManagementSystem.Services
{
    public interface IIdentityService
    {
        Task<BmsResponse> Login(string login, string passwordHash);
        Task LogOut();
        Task RefreshToken();

        Task<UserProfileResponse> UserProfile();
    }
}

