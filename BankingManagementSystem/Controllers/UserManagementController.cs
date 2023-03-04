using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _service;
		public UserManagementController(IUserManagementService service)
		{
            _service = service;
		}

        [HttpPost]
        public Task<BmsResponse> CreateNewUser(NewUserDto newUser)
        {
            return _service.CreateNewUser(newUser);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task<List<BmsUserProjection>> UserList()
        {
            return _service.UserList();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task<List<BmsRoleProjection>> RoleList()
        {
            return _service.RoleList();
        }
    }
}

