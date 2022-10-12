using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core.Domains.Account
{
    public class HistoryOfMoneyTransfers
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
    }
}
