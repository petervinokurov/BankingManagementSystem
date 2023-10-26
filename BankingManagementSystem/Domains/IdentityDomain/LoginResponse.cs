using BankingManagementSystem.Dto;

namespace BankingManagementSystem.IdentityDomain;

public class LoginResponse : BmsResponse
{
    public string AccessToken { get; set; }

    public string XsrfToken { get; set; }
}