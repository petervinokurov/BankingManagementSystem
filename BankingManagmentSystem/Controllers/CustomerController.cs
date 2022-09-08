using System;
using System.Collections.Generic;
using BankingManagmentSystem.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BankingManagmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
        }

        [HttpPost]
        public int CreateCustomer(CustomerDto customer)
        {
            return 0;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Customers()
        {
            return new List<CustomerDto> { new CustomerDto { Id = 1, CreatedAt = DateTime.UtcNow, Name = "FullName" } };
        }
    }
}
