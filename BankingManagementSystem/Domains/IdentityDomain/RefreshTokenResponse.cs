using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.IdentityDomain;

public class RefreshTokenResponse : BmsResponse
{
    public string AccessToken { get; set; } 
}