using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Entities
{
    public class Account : IConcurrencyVulnerable
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Number { get; set; }

        public decimal Balance { get; set; }

        public string CurrencyCode { get; set; }

        public Currency Currency { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
        
        public string ConcurrencyStamp { get; set; }
    }
}
