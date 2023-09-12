using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class CreateRolesRequest
{
    public IEnumerable<RoleDto> NewRoles { get; set; } = new List<RoleDto>();
}