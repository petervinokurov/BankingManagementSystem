using System.Collections.Generic;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Queries;

public class GetRolesQuery : IRequest<List<BmsRoleProjection>>
{
}