using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Dto;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ConcurrencyStamp { get; set; } = string.Empty;
    public List<ClaimDto> RoleClaims { get; set; } = new();

}