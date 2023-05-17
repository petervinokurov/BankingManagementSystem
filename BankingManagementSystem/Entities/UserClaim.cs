using System;
using Microsoft.AspNetCore.Identity;

namespace BankingManagementSystem.Entities;

public class UserClaim : IdentityUserClaim<Guid>
{
    public virtual User User { get; set; }
}