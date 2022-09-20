using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public Task<List<CustomerDto>> Customers()
        {
            return _customerService.CutomersList();
        }
    }
}
