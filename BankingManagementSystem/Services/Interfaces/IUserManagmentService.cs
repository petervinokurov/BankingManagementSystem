
using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Services
{
	public interface IUserManagementService
	{
		Task<BmsResponse> CreateNewUser(NewUserDto newUser);
		Task<List<BmsUserProjection>> UserList();
		Task<List<BmsRoleProjection>> RoleList();
	}
}

