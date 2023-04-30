using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly BankingManagementSystemContext _context;
        private readonly IMapper _mapper;
		public UserManagementController(IUserManagementService service,
            BankingManagementSystemContext context,
            IMapper mapper,
            IClaimPairsService claimPairsService)
		{
            _service = service;
            _claimPairsService = claimPairsService;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public Task<BmsResponse> CreateNewUser(NewUserDto newUser)
        {
            return _service.CreateNewUser(newUser);
        }

        [HttpGet]
        public Task<List<BmsUserProjection>> UserList()
        {
            return _service.UserList();
        }

        [HttpGet]
        public Task<List<BmsRoleProjection>> RoleList()
        {
            return _service.RoleList();
        }
        
        [HttpGet]
        public HashSet<RoleClaimDto> ClaimList()
        {
            return _claimPairsService.ClaimPairs();
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

        [HttpDelete] public Task DeleteRoles([FromQuery]List<Guid> request)
        {
            return _service.DeleteRoles(request);
        }
        
    }
}

