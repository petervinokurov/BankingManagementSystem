using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankingManagementSystem.Domains.UserManagementDomain;
using BankingManagementSystem.Domains.UserManagementDomain.Commands;
using BankingManagementSystem.Domains.UserManagementDomain.Queries;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Dto;
using MediatR;
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
        private readonly IMediator _mediator;
		public UserManagementController(IMediator mediatr)
		{
            _mediator = mediatr;
        }

        [HttpPost] public Task<CreateUsersResponse> CreateNewUsers(CreateUsersCommand command, CancellationToken token)
        {
            return _mediator.Send(command, token);
        }
        
        [HttpPut] public Task<UpdateUsersResponse> UpdateUsers(UpdateUsersCommand request, CancellationToken token)
        {
            return _mediator.Send(request, token);
        }

        [HttpDelete] public Task<DeleteUsersResponse> DeleteUsers([FromQuery]DeleteUsersCommand request, CancellationToken token)
        {
            return _mediator.Send(request, token);
        }

        [HttpGet]
        public Task<List<UserDto>> UserList(CancellationToken token)
        {
            return _mediator.Send(new GetUsersQuery(), token);
        }

        [HttpGet] public Task<List<BmsRoleProjection>> RoleList(CancellationToken token)
        {
            return _mediator.Send(new GetRolesQuery(), token);
        }
        
        [HttpGet] public Task<HashSet<ClaimDto>> ClaimList()
        {
            return _mediator.Send(new GetClaimsQuery());
        }

        [HttpPost] public Task<CreateRolesResponse> CreateNewRoles(CreateRolesCommand request, CancellationToken token)
        {
            return _mediator.Send(request, token);
        }

        [HttpPut] public Task<UpdateRolesResponse> UpdateRoles(UpdateRolesCommand request, CancellationToken token)
        {
            return _mediator.Send(request, token);
        }

        [HttpDelete] public Task<DeleteRolesResponse> DeleteRoles([FromQuery]DeleteRolesCommand request, CancellationToken token)
        {
            return _mediator.Send(request, token);
        }
        
    }
}

