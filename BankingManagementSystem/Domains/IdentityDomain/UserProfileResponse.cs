using BankingManagementSystem.Dto;

namespace BankingManagementSystem.IdentityDomain;

public class UserProfileResponse : BmsResponse
{
    public UserProfileDto User { get; set; }
}