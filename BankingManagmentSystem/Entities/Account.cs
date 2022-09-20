using System;
using System.Collections.Generic;

namespace BankingManagmentSystem.Entities
{
    public class Account : DomainEntity
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
    }
}
