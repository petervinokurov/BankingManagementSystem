using System.Collections.Generic;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Dto;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class CreateRolesCommand : IRequest<CreateRolesResponse>
{
    public IEnumerable<RoleDto> NewRoles { get; set; } = new List<RoleDto>();
}