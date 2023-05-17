using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Entities;
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
        private readonly IClaimPairsService _claimPairsService;
		public UserManagementController(IUserManagementService service,
            IClaimPairsService claimPairsService)
		{
            _service = service;
            _claimPairsService = claimPairsService;
        }

        [HttpPost] public Task<BmsResponse> CreateNewUser(NewUserDto newUser)
        {
            return _service.CreateNewUser(newUser);
        }
        
        [HttpPost] public Task<BmsResponse> CreateNewUsers(IEnumerable<NewUserDto> newUsers)
        {
            return _service.CreateNewUsers(newUsers);
        }
        
        [HttpPut] public Task UpdateUsers(IEnumerable<UserDto> request)
        {
            return _service.UpdateUsers(request);
        }

        [HttpDelete] public Task DeleteUsers([FromQuery]IEnumerable<Guid> request)
        {
            return _service.DeleteUsers(request);
        }

        [HttpGet]
        public Task<List<UserDto>> UserList()
        {
            return _service.UserList();
        }

        [HttpGet] public Task<List<BmsRoleProjection>> RoleList()
        {
            return _service.RoleList();
        }
        
        [HttpGet] public HashSet<ClaimDto> ClaimList()
        {
            return _claimPairsService.ClaimPairs();
        }

        [HttpPost] public Task CreateNewRoles(IEnumerable<RoleDto> request)
        {
            return _service.CreateNewRoles(request);
        }

        [HttpPut] public Task UpdateRoles(List<RoleDto> request)
        {
            return _service.UpdateRoles(request);
        }

        [HttpDelete] public Task DeleteRoles([FromQuery]List<Guid> request)
        {
            return _service.DeleteRoles(request);
        }
        
    }
}

