namespace BankingManagementSystem
{
	public class JwtSettings
	{
		public string Key { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public double ExpirationTime { get; set; } = 90;
	}
}

