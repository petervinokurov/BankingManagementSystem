
using System.Collections.Generic;

namespace BankingManagementSystem.Entities
{
    public class Currency
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public IEnumerable<CurrencyRate> CurrencyRates { get; set; } = new List<CurrencyRate>();

        public IEnumerable<Account> Accounts { get; set; } = new List<Account>();

        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
