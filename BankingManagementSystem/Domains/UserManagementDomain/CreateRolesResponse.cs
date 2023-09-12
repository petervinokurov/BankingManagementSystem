using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class CreateRolesResponse : BmsResponse
{
    public IEnumerable<RoleDto> CreatedRoles { get; set; }
}