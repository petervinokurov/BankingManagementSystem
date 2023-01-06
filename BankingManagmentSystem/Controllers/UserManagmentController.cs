using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Services;
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

        [HttpPost()]
        public IActionResult CreateNewUser(NewUserDto newUser)
        {
            return Ok(_service.CreateNewUser(newUser));
        }
	}
}

