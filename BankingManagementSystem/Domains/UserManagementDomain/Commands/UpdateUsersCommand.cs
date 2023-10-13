using System.Collections.Generic;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Commands;

public class UpdateUsersCommand : IRequest<UpdateUsersResponse>
{
    public IEnumerable<UserDto> Users { get; set; }
}