using System;
namespace BankingManagmentSystem
{
	public class AppSettings
	{
		public JwtSettings Jwt { get; set; }

		public DatabaseSettings Database { get; set; }
	}
}

