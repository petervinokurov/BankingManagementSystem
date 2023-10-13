using System;
using System.Collections.Generic;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Commands;

public class DeleteRolesCommand : IRequest<DeleteRolesResponse>
{
    public IEnumerable<Guid> RoleIds { get; set; } = new List<Guid>();
}