using System;
using System.Collections.Generic;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Commands;

public class DeleteUsersCommand : IRequest<DeleteUsersResponse>
{
    public IEnumerable<Guid> UserIds { get; set; } = new List<Guid>();
}