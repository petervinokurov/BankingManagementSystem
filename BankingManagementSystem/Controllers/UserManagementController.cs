using System;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public Task<List<BmsRoleProjection>> RoleList()
        {
            return _service.RoleList();
        }

        [HttpPost]
        public Task CreateNewRoles(IEnumerable<RoleDto> request)
        {
            return _service.CreateNewRoles(request);
        }

        [HttpPut]
        public Task UpdateRoles(List<RoleDto> request)
        {
            return _service.UpdateRoles(request);
        }

        [HttpDelete]
        public Task DeleteRoles([FromQuery]List<Guid> request)
        {
            return _service.DeleteRoles(request);
        }
    }
}

