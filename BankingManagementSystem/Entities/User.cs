using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BankingManagementSystem.Entities
{
	public class User : IdentityUser<Guid>
	{
		
        public override string ConcurrencyStamp { get ; set ; } = Guid.NewGuid().ToString();

        public ICollection<Role> Roles { get; set; }

        public ICollection<UserClaim> Claims { get; set; }
	}
}

