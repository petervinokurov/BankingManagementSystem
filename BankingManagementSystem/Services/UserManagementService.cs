using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagementSystem.Domains.UserManagementDomain;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Dto;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Services
{
    public class UserManagementService : IUserManagementService
	{
        private readonly BankingManagementSystemContext _context;
        private readonly IMapper _mapper;

		public UserManagementService(BankingManagementSystemContext context,
            IMapper mapper)
		{
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateUsersResponse> CreateNewUsers(CreateUsersRequest request)
        {
            var response = new CreateUsersResponse();
            var existedUsers = await _context.Users.Where(r => request.NewUsers.Select(x => x.Email.ToUpperInvariant()).Contains(r.Email)).Select(x => x.Email).ToListAsync();
            response.ApplicationError = string.Join(',',existedUsers.Select(x => $"User {x} already exist.{Environment.NewLine}").ToArray());
            var newUsers = request.NewUsers.Where(r => !existedUsers.Contains(r.Email)).Select(u =>
            {
                var user = _mapper.Map<User>(u);
                user.Roles = _context.Roles.Where(r => u.Roles.Select(ur => ur.Id).Contains(r.Id)).ToList();
                return user;
            });
            await _context.Users.AddRangeAsync(newUsers);
            
            await _context.SaveChangesAsync();
            return await Task.FromResult(response);
        }

        public async Task<UpdateUsersResponse> UpdateUsers(UpdateUsersRequest request)
        {
            var response = new UpdateUsersResponse();
            var repositoryUsers = await _context.Users
                .Include(u => u.Roles)
                .Include(u => u.Claims)
                .Where(r => request.Users.Select(x => x.Id).Contains(r.Id)).ToListAsync();
            var rolesList = await _context.Roles.ToListAsync();

            repositoryUsers.ForEach(ur =>
            {
                var user = request.Users.Single(r => r.Id == ur.Id);
                _mapper.Map(user, ur);
                ur.Roles = rolesList.Where(rl => ur.Roles.Select(r => r.Id).Contains(rl.Id)).ToList();
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
           return await _context.Roles.Include(x => x.RoleClaims).ProjectTo<BmsRoleProjection>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<UserDto>> UserList()
        {
            return await _context.Users
                .Include(u=>u.Roles)
                .Include(u => u.Claims)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<CreateRolesResponse> CreateNewRoles(CreateRolesRequest request)
        {
            var response = new CreateRolesResponse();
            var roles = request.NewRoles.ToList();
            var existedRoles = await _context.Roles.Where(r => roles.Select(x => x.Name.ToUpperInvariant()).Contains(r.NormalizedName)).Select(x => x.Name).ToListAsync();
            response.ApplicationError = string.Join(',',existedRoles.Select(x => $"Role {x} already exist.").ToArray());
            var rolesEntities = roles.Where(r => !existedRoles.Contains(r.Name)).Select(r => _mapper.Map<Role>(r)).ToList();
            await _context.Roles.AddRangeAsync(rolesEntities);
            
            await _context.SaveChangesAsync();
            response.CreatedRoles = _mapper.Map<IEnumerable<RoleDto>>(rolesEntities);
            return await Task.FromResult(response);
        }

        public async Task<UpdateRolesResponse> UpdateRoles(UpdateRolesRequest request)
        {
            var response = new UpdateRolesResponse();
            var repositoryRoles = await _context.Roles.Include(r => r.RoleClaims)
                .Where(r => request.UpdateRoles.Select(x => x.Id).Contains(r.Id)).ToListAsync();

            repositoryRoles.ForEach(rr =>
            {
                var role = request.UpdateRoles.Single(r => r.Id == rr.Id);
                _mapper.Map(role, rr);
            });
            await _context.SaveChangesAsync();
            response.UpdatedRoles = _mapper.Map<IEnumerable<RoleDto>>(repositoryRoles);
            return await Task.FromResult(response);
        }

        public async Task<DeleteRolesResponse> DeleteRoles(DeleteRolesRequest request)
        {
            var response = new DeleteRolesResponse();
            var rolesToRemove = await _context.Roles.Where(r => request.RoleIds.Contains(r.Id)).ToListAsync();
            //TODO Add input validation.
            _context.Roles.RemoveRange(rolesToRemove);
            await _context.SaveChangesAsync();
            response.DeletedRoleIds = rolesToRemove.Select(r => r.Id).ToList();
            return await Task.FromResult(response);
        }
    }
}

