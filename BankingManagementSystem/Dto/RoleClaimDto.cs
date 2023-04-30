using System.Diagnostics.CodeAnalysis;

namespace BankingManagementSystem.Dto;

public class RoleClaimDto
{
    private const string Delimiter = "::";
    [NotNull] public string ClaimType { get; init; }
    [NotNull] public string ClaimValue { get; init; }

    public string ClaimView => $"{ClaimType}{Delimiter}{ClaimValue}";

    public RoleClaimDto(string claimPair)
    {
        var claimData = claimPair.Split(Delimiter);
        ClaimType = claimData[0];
        ClaimValue = claimData[1];
    }

    public RoleClaimDto()
    {
        ClaimValue = string.Empty;
        ClaimType = string.Empty;
    }

    public RoleClaimDto([NotNull]string claimType, [NotNull]string claimValue)
    {
        ClaimValue = claimValue;
        ClaimType = claimType;
    }
}