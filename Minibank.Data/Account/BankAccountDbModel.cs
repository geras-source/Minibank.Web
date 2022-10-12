using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Data.Account
{
    [Table("BankAccounts")]
    public class BankAccountDbModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public bool IsClosed { get; set; }
        public DateTime DateOfOpening { get; set; }
        public DateTime DateOfClosing { get; set; }
    }
}
