using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankingManagementSystem.Domains.UserManagementDomain.Queries;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Services;
using MediatR;

namespace BankingManagementSystem.Domains.UserManagementDomain.Handlers;

public class GetClaimsQueryHandler : IRequestHandler<GetClaimsQuery, HashSet<ClaimDto>>
{
    private readonly IClaimPairsService _claimPairsService;

    public GetClaimsQueryHandler(IClaimPairsService claimPairsService)
    {
        _claimPairsService = claimPairsService;
    }
    
    public Task<HashSet<ClaimDto>> Handle(GetClaimsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_claimPairsService.ClaimPairs());
    }
}