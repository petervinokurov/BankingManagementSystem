using System;
using BankingManagementSystem.Dto;
using BankingManagementSystem.SignalRHubs;
using TypeGen.Core.SpecGeneration;

namespace BankingManagementSystem;

public class TypesGenerationSpec : GenerationSpec
{
    private const string FrontendPath = "../BankingManagementSystem.Angular/src/app/";
    private readonly string _defaultId = $"'{Guid.Empty.ToString()}'";
    public override void OnBeforeGeneration(OnBeforeGenerationArgs args)
    {
        AddClass<ClaimDto>(outputDir: $"{FrontendPath}generated-dto");
        AddClass<RoleDto>(outputDir: $"{FrontendPath}generated-dto").Member(nameof(RoleDto.Id)).DefaultValue(_defaultId);
        AddClass<UserDto>(outputDir: $"{FrontendPath}generated-dto").Member(nameof(UserDto.Id)).DefaultValue(_defaultId);
        AddClass<UserManagementHubEvents>(outputDir: $"{FrontendPath}user-management");
    }
}