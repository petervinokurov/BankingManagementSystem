using System;
using Microsoft.AspNetCore.Identity;

namespace BankingManagmentSystem.Entities
{
	public class BmcUser : IdentityUser<Guid>
	{
		public BmcUser()
		{
		}

        public override string ConcurrencyStamp { get ; set ; } = Guid.NewGuid().ToString();
    }
}

