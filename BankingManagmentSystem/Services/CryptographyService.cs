using System;
using System.Security.Cryptography;
using System.Text;

namespace BankingManagmentSystem.Services
{
	public class CryptographyService : ICryptographyService
	{
		public CryptographyService()
		{
		}

        public string GetPasswordHash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}

