using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserManagmentController : ControllerBase
    {
        private readonly IUserManagmentService _service;
		public UserManagmentController(IUserManagmentService service)
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
	}
}

