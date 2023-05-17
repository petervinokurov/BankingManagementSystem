using System;
using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem
{
	public class BmsRoleProjection
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
		
		public string ConcurrencyStamp { get; set; }

		public List<ClaimDto> RoleClaims { get; set; }
	}
}

