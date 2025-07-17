namespace BankingManagementSystem
{
	public class AppSettings
	{
		public JwtSettings Jwt { get; set; }

		public DatabaseSettings ConnectionStrings { get; set; }

		public CsrfSettings Csrf { get; set; }
	}
}

