using System;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;

namespace BankingManagmentSystem.Services
{
	public interface IUserManagmentService
	{
		Task<BmsResponse> CreateNewUser(NewUserDto newUser);

	}
}

