using System;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagmentController : ControllerBase
    {
        private readonly IUserManagmentService _service;
		public UserManagmentController(IUserManagmentService service)
		{
            _service = service;
		}

        [Route("create-new-user")]
        [HttpPost()]
        public IActionResult CreateNewUser(NewUserDto newUser)
        {
            return (IActionResult)_service.CreateNewUser(newUser);
        }
	}
}

