using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web.Entities
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
