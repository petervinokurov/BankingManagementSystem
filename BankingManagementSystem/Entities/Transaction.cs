using System;
namespace BankingManagementSystem.Entities
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; }

        public Currency Currency { get; set; }

        public int CurrencyRateId { get; set; }

        public CurrencyRate CurrencyOnDate { get; set; }

        public DateTime? Processing { get; set; }

        public decimal? ProcessedValue { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public TransactionType Type { get; set; }
    }
}
