using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core.Domains.Account
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public bool IsClosed { get; set; }
        public DateTime DateOfOpening { get; set; }
        public DateTime DateOfClosing { get; set; }
    }
}
