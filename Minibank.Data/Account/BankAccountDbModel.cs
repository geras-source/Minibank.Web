using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Data.Account
{
    public class BankAccountDbModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public bool IsClosed { get; set; }
        public DateTime DateOfOpening { get; set; }
        public DateTime DateOfClosing { get; set; }
    }
}
