using System.Collections.Generic;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Queries;

public class GetUsersQuery : IRequest<List<UserDto>>
{
    
}