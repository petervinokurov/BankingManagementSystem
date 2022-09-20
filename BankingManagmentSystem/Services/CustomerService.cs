using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingManagmentSystem.Services
{
    public class CustomerService : PaginationService<Customer>, ICustomerService
    {
        public BankingManagmentSystemContext _context;
        public IMapper _mapper;

        public CustomerService(BankingManagmentSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<CustomerDto>> CutomersList()
        {
            var query = _context.Customers.AsQueryable();
            
            query = PaginatedQuery(query);
            
            return query.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToListAsync(); 
        }
    }
}
