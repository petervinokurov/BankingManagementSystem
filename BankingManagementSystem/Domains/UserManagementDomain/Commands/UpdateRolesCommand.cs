using System.Collections.Generic;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Dto;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Commands;

public class UpdateRolesCommand  : IRequest<UpdateRolesResponse>
{
    public IEnumerable<RoleDto> UpdateRoles { get; set; } = new List<RoleDto>();
}