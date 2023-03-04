using System;
using System.Security.Cryptography;
using System.Text;

namespace BankingManagementSystem.Services
{
	public class CryptographyService : ICryptographyService
	{
        public string GetPasswordHash(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}

