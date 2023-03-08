namespace BankingManagementSystem.Services
{
	public interface ICryptographyService
	{
		string GetPasswordHash(string password);
	}
}

