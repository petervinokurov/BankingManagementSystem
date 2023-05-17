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
                _context.Users.AddAsync(_mapper.Map<User>(newUser));
                _context.SaveChangesAsync();
            }
            return Task.FromResult(result);
        }

        public async Task<BmsResponse> CreateNewUsers(IEnumerable<NewUserDto> newUsers)
        {
            var response = new BmsResponse();
            await _context.Roles.ToListAsync();
            var existedRoles = await _context.Users.Where(r => newUsers.Select(x => x.Email.ToUpperInvariant()).Contains(r.Email)).Select(x => x.Email).ToListAsync();
            response.ApplicationError = string.Join(',',existedRoles.Select(x => $"User {x} already exist.").ToArray());
            await _context.Users.AddRangeAsync(newUsers.Where(r => !existedRoles.Contains(r.Email)).Select(r =>
            {
                var user = _mapper.Map<User>(r);
                user.Roles = _context.Roles.Where(r => user.Roles.Select(ur => ur.Id).Contains(r.Id)).ToList();
                return user;
            }));
            
            await _context.SaveChangesAsync();
            return await Task.FromResult(response);
        }

        public async Task<BmsResponse> UpdateUsers(IEnumerable<UserDto> users)
        {
            var response = new BmsResponse();
            var repositoryUsers = await _context.Users
                .Include(r => r.Claims)
                .Include(r => r.Roles)
                .Where(r => users.Select(x => x.Id).Contains(r.Id)).ToListAsync();

            repositoryUsers.ForEach(rr =>
            {
                var user = users.Single(r => r.Id == rr.Id);
                _mapper.Map(user, rr);
            });
            await _context.SaveChangesAsync();
            return await Task.FromResult(response);
        }

        public async Task<BmsResponse> DeleteUsers(IEnumerable<Guid> userIds)
        {
            var response = new BmsResponse();
            var usersToRemove = _context.Users
                .Include(u => u.Roles)
                .Include(u => u.Claims)
                .Where(r => userIds.Contains(r.Id));
            _context.Users.RemoveRange(usersToRemove);
            await _context.SaveChangesAsync();
            return await Task.FromResult(response);
        }

        public async Task<List<BmsRoleProjection>> RoleList()
        {
           return await _context.Roles.ProjectTo<BmsRoleProjection>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<UserDto>> UserList()
        {
            return await _context.Users.ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<BmsResponse> CreateNewRoles(IEnumerable<RoleDto> roles)
        {
            var response = new BmsResponse();
            var existedRoles = await _context.Roles.Where(r => roles.Select(x => x.Name.ToUpperInvariant()).Contains(r.NormalizedName)).Select(x => x.Name).ToListAsync();
            response.ApplicationError = string.Join(',',existedRoles.Select(x => $"Role {x} already exist.").ToArray());
            await _context.Roles.AddRangeAsync(roles.Where(r => !existedRoles.Contains(r.Name)).Select(r => new Role
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
            var repositoryRoles = await _context.Roles.Include(r => r.RoleClaims)
                .Where(r => roles.Select(x => x.Id).Contains(r.Id)).ToListAsync();

            repositoryRoles.ForEach(rr =>
            {
                var role = roles.Single(r => r.Id == rr.Id);
                _mapper.Map(role, rr);
            });
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

