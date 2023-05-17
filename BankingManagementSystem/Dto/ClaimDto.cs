using System.Diagnostics.CodeAnalysis;

namespace BankingManagementSystem.Dto;

public class ClaimDto
{
    private const string Delimiter = "::";
    [NotNull] public string ClaimType { get; init; }
    [NotNull] public string ClaimValue { get; init; }

    public string ClaimView => $"{ClaimType}{Delimiter}{ClaimValue}";

    public ClaimDto(string claimPair)
    {
        var claimData = claimPair.Split(Delimiter);
        ClaimType = claimData[0];
        ClaimValue = claimData[1];
    }

    public ClaimDto()
    {
        ClaimValue = string.Empty;
        ClaimType = string.Empty;
    }

    public ClaimDto([NotNull]string claimType, [NotNull]string claimValue)
    {
        ClaimValue = claimValue;
        ClaimType = claimType;
    }
}