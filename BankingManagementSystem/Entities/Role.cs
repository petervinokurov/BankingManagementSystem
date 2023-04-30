using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BankingManagementSystem.Entities
{
	public class Role : IdentityRole<Guid>
	{
		public virtual ICollection<RoleClaim> RoleClaims { get; set; }
 
		public ICollection<User> Users { get; set; }
	}
}

