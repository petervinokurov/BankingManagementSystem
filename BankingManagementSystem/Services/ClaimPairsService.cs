using System.Collections.Generic;
using System.Linq;
using BankingManagementSystem.Controllers;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Services;

public class ClaimPairsService : IClaimPairsService
{
    private readonly HashSet<string> _claimTypes = new();
    private readonly HashSet<string> _claimValues = new();

    public ClaimPairsService()
    {
        _claimTypes.Add(nameof(UserManagementController));
        _claimTypes.Add(nameof(CustomerController));
        _claimValues.Add("Read");
        _claimValues.Add("Wright");
    }

    public HashSet<RoleClaimDto> ClaimPairs()
    {
        return _claimTypes.SelectMany(ct => _claimValues.Select(cv => new RoleClaimDto(ct, cv) )).ToHashSet();
    }
}