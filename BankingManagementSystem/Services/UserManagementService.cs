using System;
using System.Collections.Generic;
using System.Globalization;
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

        public async Task<BmsResponse> CreateNewRoles(IEnumerable<RoleDto> roles)
        {
            var response = new BmsResponse();
            var existedRoles = await _context.Roles.Where(r => roles.Select(x => x.Name.ToUpperInvariant()).Contains(r.NormalizedName)).Select(x => x.Name).ToListAsync();
            response.ApplicationError = string.Join(',',existedRoles.Select(x => $"Role {x} already exist.").ToArray());
            await _context.Roles.AddRangeAsync(roles.Where(r => !existedRoles.Contains(r.Name)).Select(r => new BmsRole
            {
                Id = r.Id, 
                Name = r.Name, 
                NormalizedName = r.Name.ToUpperInvariant(), 
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }));
            await _context.SaveChangesAsync();
            return await Task.FromResult(response);
        }

        public async Task<BmsResponse> UpdateRoles(List<RoleDto> roles)
        {
            var response = new BmsResponse();
            var repositoryRoles = await _context.Roles
                .Where(r => roles.Select(x => x.Id).Contains(r.Id)).ToListAsync();
            
            var existedRoles = repositoryRoles.Where(r => roles.Select(x => x.Name.ToUpperInvariant()).Contains(r.NormalizedName)).Select(x => x.Name).ToList();
            response.ApplicationError = string.Join(',',existedRoles.Select(x => $"Role {x} already exist.").ToArray());
            var rolesForUpdate = roles.Where(r => !existedRoles.Contains(r.Name)).ToList();
            repositoryRoles.ForEach(rr =>
                {
                    var role = rolesForUpdate.Single(r => r.Id == rr.Id);
                    rr.Name = role.Name;
                    rr.NormalizedName = role.Name.ToUpperInvariant();
                }
            );
            await _context.SaveChangesAsync();
            return await Task.FromResult(response);
        }

        public async Task<BmsResponse> DeleteRoles(List<Guid> roleIds)
        {
            var response = new BmsResponse();
            var rolesToRemove = _context.Roles.Where(r => roleIds.Contains(r.Id));
            _context.Roles.RemoveRange(rolesToRemove);
            await _context.SaveChangesAsync();
            return await Task.FromResult(response);
        }
        
    }
}

