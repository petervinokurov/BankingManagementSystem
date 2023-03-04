using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Dto;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Services
{
    public class UserManagementService : IUserManagementService
	{
        private readonly BankingManagementSystemContext _context;
        private readonly ICryptographyService _cryptographyService;
        private readonly IMapper _mapper;

		public UserManagementService(BankingManagementSystemContext context,
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
                _context.Users.AddAsync(new BmsUser
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

        public async Task<List<BmsRoleProjection>> RoleList()
        {
            return await _context.Roles.ProjectTo<BmsRoleProjection>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<BmsUserProjection>> UserList()
        {
            return await _context.Users.ProjectTo<BmsUserProjection>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}

