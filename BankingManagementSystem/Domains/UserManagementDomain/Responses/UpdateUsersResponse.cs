using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain.Responses;

public class UpdateUsersResponse : BmsResponse
{
    public IEnumerable<UserDto> Users { get; set; }
}