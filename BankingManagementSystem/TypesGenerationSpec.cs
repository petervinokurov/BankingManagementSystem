using BankingManagementSystem.Dto;
using BankingManagementSystem.SignalRHubs;
using TypeGen.Core.SpecGeneration;

namespace BankingManagementSystem;

public class TypesGenerationSpec : GenerationSpec
{
    public override void OnBeforeGeneration(OnBeforeGenerationArgs args)
    {
        AddClass<ClaimDto>(outputDir: "../BankingManagementSystem.Angular/src/app/generated-dto");
        AddClass<UserManagementHubEvents>(outputDir: "../BankingManagementSystem.Angular/src/app/user-management");
    }
}