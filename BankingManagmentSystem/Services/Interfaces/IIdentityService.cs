using System;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;

namespace BankingManagmentSystem.Services
{
    public interface IIdentityService
    {
        Task<BmsResponse> Login(string login, string passwordHash);
        Task LogOut();
        Task RefreshToken();
    }
}

