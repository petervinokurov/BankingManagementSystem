using System;
using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem
{
	public class UserDto
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public List<RoleDto> Roles { get; set; }

		public List<ClaimDto> Claims { get; set; }
	}
}