using System;
using Microsoft.AspNetCore.Identity;

namespace BankingManagmentSystem.Entities
{
	public class BmcUser : IdentityUser<Guid>
	{
		public BmcUser()
		{
		}
	}
}

