using BankingManagementSystem.Dto;

namespace BankingManagementSystem.IdentityDomain;

public class UserProfileResponse : BmsResponse
{
    public UserDto User { get; set; }
}