using System;
namespace BankingManagmentSystem.Services
{
	public interface ICryptographyService
	{
		string GetPasswordHash(string password);
	}
}

