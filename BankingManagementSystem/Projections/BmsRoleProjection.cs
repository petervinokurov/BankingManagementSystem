using System;
namespace BankingManagementSystem
{
	public class BmsRoleProjection
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
		
		public string ConcurrencyStamp { get; set; }
	}
}

