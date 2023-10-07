
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagementSystem.Domains.UserManagementDomain;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Entities;

namespace BankingManagementSystem.Services
{
	public interface IUserManagementService
	{
		Task<CreateUsersResponse> CreateNewUsers(CreateUsersRequest request);
		Task<UpdateUsersResponse> UpdateUsers(UpdateUsersRequest request);
		Task<DeleteUsersResponse> DeleteUsers(DeleteUsersRequest request);
		Task<List<UserDto>> UserList();
		Task<List<BmsRoleProjection>> RoleList();
		Task<CreateRolesResponse> CreateNewRoles(CreateRolesRequest request);
		Task<UpdateRolesResponse> UpdateRoles(UpdateRolesRequest request);
		Task<DeleteRolesResponse> DeleteRoles(DeleteRolesRequest request);
	}
}

