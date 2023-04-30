using System;
using Microsoft.AspNetCore.Identity;

namespace BankingManagementSystem.Entities;

public class RoleClaim : IdentityRoleClaim<Guid>
{
    public virtual Role Role { get; set; }
}