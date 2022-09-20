using System;
using System.Linq;
using BankingManagmentSystem.Entities;

namespace BankingManagmentSystem.Services
{
    public class PaginationService<T> where T : DomainEntity
    {
        public PaginationService()
        {
        }

        protected IQueryable<T> PaginatedQuery(IQueryable<T> query, int page = 0, int pageSize = 10)
        {
            return query.Skip(page * pageSize).Take(pageSize);
        }
    }
}
