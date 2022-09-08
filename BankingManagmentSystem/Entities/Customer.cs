using System;
using System.Collections.Generic;

namespace BankingManagmentSystem.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public IEnumerable<Account> Accounts { get; set; }
    }
}
