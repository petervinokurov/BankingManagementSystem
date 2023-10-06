using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class CreateUsersResponse : BmsResponse
{
    public IEnumerable<UserDto> NewUsers { get; set; }
}