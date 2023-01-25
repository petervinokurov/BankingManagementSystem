using System;
using BankingManagmentSystem.Dto;

namespace BankingManagmentSystem.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string audience, BmsUserProjection user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}

