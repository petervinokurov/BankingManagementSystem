using System;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IdentityController : ControllerBase
    {
        private IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public Task<BmsResponse> Login(SignInDto model)
        {
            return _identityService.Login(model.Username, model.Password);
        }

        [HttpGet]
        public Task LogOut()
        {
            return _identityService.LogOut();
        }
    }
}

