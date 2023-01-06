using System;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("login")]
        public IActionResult Token(SignInDto model)
        {
            return Ok(_identityService.Login(model.Username, model.Password));
        }
    }
}

