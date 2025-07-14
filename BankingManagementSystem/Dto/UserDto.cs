using System;
using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem
{
	public class UserDto
	{
		public Guid Id { get; set; }

		public string UserName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public List<RoleDto> Roles { get; set; } = new();

		public List<ClaimDto> Claims { get; set; } = new();
	}
}