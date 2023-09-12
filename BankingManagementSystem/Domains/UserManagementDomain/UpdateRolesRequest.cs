using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class UpdateRolesRequest
{
    public IEnumerable<RoleDto> UpdateRoles { get; set; } = new List<RoleDto>();
}