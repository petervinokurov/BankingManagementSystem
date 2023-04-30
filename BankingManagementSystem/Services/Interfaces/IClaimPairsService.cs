using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Services;

public interface IClaimPairsService
{
    HashSet<RoleClaimDto> ClaimPairs();
}