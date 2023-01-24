using System;
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
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public int CreateCustomer(CustomerDto customer)
        {
            return 0;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task<List<CustomerDto>> Customers()
        {
            return _customerService.CutomersList();
        }
    }
}
