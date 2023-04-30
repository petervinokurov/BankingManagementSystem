using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Dto;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ConcurrencyStamp { get; set; }
    public List<RoleClaimDto> RoleClaims { get; set; }
}