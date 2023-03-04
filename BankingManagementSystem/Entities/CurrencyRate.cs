using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Entities
{
    public class CurrencyRate
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Value { get; set; }

        public DateTime OnDate { get; set; }

        public string CurrencyCode { get; set; }

        public Currency Currency { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
