namespace BankingManagementSystem
{
	public class AppSettings
	{
		public JwtSettings Jwt { get; set; }

		public DatabaseSettings Database { get; set; }

		public CsrfSettings Csrf { get; set; }
	}
}

