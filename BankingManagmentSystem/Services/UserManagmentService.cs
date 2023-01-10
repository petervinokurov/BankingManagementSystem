using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingManagmentSystem.Services
{
    public class UserManagmentService : IUserManagmentService
	{
        private readonly BankingManagmentSystemContext _context;
        private readonly ICryptographyService _cryptographyService;
        private readonly IMapper _mapper;

		public UserManagmentService(BankingManagmentSystemContext context,
            ICryptographyService cryptographyService,
            IMapper mapper)
		{
            _context = context;
            _cryptographyService = cryptographyService;
            _mapper = mapper;
		}

        public Task<BmsResponse> CreateNewUser(NewUserDto newUser)
        {
            var result = new BmsResponse();
            if (_context.Users.Any(u => u.NormalizedEmail == newUser.Username.ToUpperInvariant()))
            {
                result.ApplicationError = $"User '{newUser.Username}' already exist.";
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
            }
            return Task.FromResult(result);
        }

        public async Task<List<BmsUserProjection>> UserList()
        {
            return await _context.Users.ProjectTo<BmsUserProjection>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}

