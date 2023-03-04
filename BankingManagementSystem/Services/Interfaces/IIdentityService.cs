using System;
using System.Threading.Tasks;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Services
{
    public interface IIdentityService
    {
        Task<BmsResponse> Login(string login, string passwordHash);
        Task LogOut();
        Task RefreshToken();
    }
}

