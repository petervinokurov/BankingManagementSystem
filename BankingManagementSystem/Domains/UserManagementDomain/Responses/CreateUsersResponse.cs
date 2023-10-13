using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain.Responses;

public class CreateUsersResponse : BmsResponse
{
    public IEnumerable<UserDto> NewUsers { get; set; }
}