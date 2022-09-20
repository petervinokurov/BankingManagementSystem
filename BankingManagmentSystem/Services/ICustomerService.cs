using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankingManagmentSystem.Dto;

namespace BankingManagmentSystem.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> CutomersList(); 
    }
}
