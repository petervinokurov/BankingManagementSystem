using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BankingManagementSystem.Dto
{
	public class NewUserDto
	{
		[NotNull]public string Username { get; set; }

		[NotNull]public string Email { get; set; }

		[NotNull]public string Password { get; set; }
		
		public List<RoleDto> Roles { get; set; }

		public List<ClaimDto> Claims { get; set; }
	}
}

