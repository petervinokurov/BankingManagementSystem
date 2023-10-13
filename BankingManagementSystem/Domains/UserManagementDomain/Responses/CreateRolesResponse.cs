using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain.Responses;

public class CreateRolesResponse : BmsResponse
{
    public IEnumerable<RoleDto> CreatedRoles { get; set; }
}