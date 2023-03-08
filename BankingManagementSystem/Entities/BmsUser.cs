using System;
using Microsoft.AspNetCore.Identity;

namespace BankingManagementSystem.Entities
{
	public class BmsUser : IdentityUser<Guid>
	{
		
        public override string ConcurrencyStamp { get ; set ; } = Guid.NewGuid().ToString();
    }
}

