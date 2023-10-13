using System.Collections.Generic;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Commands;

public class CreateUsersCommand : IRequest<CreateUsersResponse>
{
    public IEnumerable<UserDto> NewUsers { get; set; }
}