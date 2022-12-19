using System;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;

namespace BankingManagmentSystem.Services
{
    public interface IIdentityService
    {
        Task Login(string login, string passwordHash);
        Task LogOut(string login);
        Task RefreshToken();
    }
}

