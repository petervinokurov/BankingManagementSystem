using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Dto;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BankingManagementSystemContext _context;
        private readonly IMapper _mapper;

        public CustomerService(BankingManagementSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<CustomerDto>> CustomersList()
        {
            var query = _context.Customers.AsQueryable();
            return query.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToListAsync(); 
        }
    }
}
