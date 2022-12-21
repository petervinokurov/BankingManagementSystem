using System;
using System.Linq;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Entities;

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

        public Task CreateNewUser(NewUserDto newUser)
        {
            if (_context.Users.Any(u => u.UserName == newUser.Username ))
            {
                return Task.CompletedTask;
            }
            else
            {
                _context.Users.AddAsync(new BmcUser { UserName = newUser.Username, PasswordHash = _cryptographyService.GetPasswordHash(newUser.Password) });
                _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
        }
    }
}

