using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> CustomersList(); 
    }
}
