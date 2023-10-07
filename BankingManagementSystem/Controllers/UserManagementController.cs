using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagementSystem.Domains.UserManagementDomain;
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
        private readonly IClaimPairsService _claimPairsService;
		public UserManagementController(IUserManagementService service,
            IClaimPairsService claimPairsService)
		{
            _service = service;
            _claimPairsService = claimPairsService;
        }

        [HttpPost] public Task<CreateUsersResponse> CreateNewUsers(CreateUsersRequest request)
        {
            return _service.CreateNewUsers(request);
        }
        
        [HttpPut] public Task<UpdateUsersResponse> UpdateUsers(UpdateUsersRequest request)
        {
            return _service.UpdateUsers(request);
        }

        [HttpDelete] public Task<DeleteUsersResponse> DeleteUsers([FromQuery]DeleteUsersRequest request)
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

        [HttpPost] public Task<CreateRolesResponse> CreateNewRoles(CreateRolesRequest request)
        {
            return _service.CreateNewRoles(request);
        }

        [HttpPut] public Task<UpdateRolesResponse> UpdateRoles(UpdateRolesRequest request)
        {
            return _service.UpdateRoles(request);
        }

        [HttpDelete] public Task<DeleteRolesResponse> DeleteRoles([FromQuery]DeleteRolesRequest request)
        {
            return _service.DeleteRoles(request);
        }
        
    }
}

