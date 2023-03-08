using System;

namespace BankingManagementSystem.Dto;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string ConcurrencyStamp { get; set; }
}