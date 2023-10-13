using System.Collections.Generic;
using BankingManagementSystem.Dto;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Queries;

public class GetClaimsQuery : IRequest<HashSet<ClaimDto>>
{
    
}