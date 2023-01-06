using System;
using System.Linq;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Entities;
using Microsoft.AspNetCore.Http;

namespace BankingManagmentSystem.Services
{
	public class UserManagmentService : IUserManagmentService
	{
        private readonly BankingManagmentSystemContext _context;
        private readonly ICryptographyService _cryptographyService;

		public UserManagmentService(BankingManagmentSystemContext context, ICryptographyService cryptographyService)
		{
            _context = context;
            _cryptographyService = cryptographyService;
		}

        public Task<BmsResponse> CreateNewUser(NewUserDto newUser)
        {
            if (_context.Users.Any(u => u.NormalizedEmail == newUser.Username.ToUpperInvariant()))
            {
                return Task.FromResult(new BmsResponse { ApplicationError = $"User '{newUser.Username}' already exist." });
            }
            else
            {
                _context.Users.AddAsync(new BmcUser
                {
                    Email = newUser.Username,
                    NormalizedEmail = newUser.Username.ToUpperInvariant(),
                    PasswordHash = _cryptographyService.GetPasswordHash(newUser.Password),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    TwoFactorEnabled = false
                });
                _context.SaveChangesAsync();
                return Task.FromResult(new BmsResponse());
            }
        }
    }
}

