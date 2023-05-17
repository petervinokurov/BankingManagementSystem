
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Entities;

namespace BankingManagementSystem.Services
{
	public interface IUserManagementService
	{
		Task<BmsResponse> CreateNewUser(NewUserDto newUser);
		Task<BmsResponse> CreateNewUsers(IEnumerable<NewUserDto> newUsers);
		Task<BmsResponse> UpdateUsers(IEnumerable<UserDto> users);
		Task<BmsResponse> DeleteUsers(IEnumerable<Guid> userIds);
		Task<List<UserDto>> UserList();
		Task<List<BmsRoleProjection>> RoleList();
		Task<BmsResponse> CreateNewRoles(IEnumerable<RoleDto> roles);
		Task<BmsResponse> UpdateRoles(List<RoleDto> roles);
		Task<BmsResponse> DeleteRoles(List<Guid> roleIds);
	}
}

