using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain.Responses;

public class UpdateRolesResponse : BmsResponse
{
    public IEnumerable<RoleDto> UpdatedRoles { get; set; } = new List<RoleDto>();
}