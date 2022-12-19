using System;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Projections;

namespace BankingManagmentSystem.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, BmcUserProjection user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}

