using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Data.Account
{
    [Table("HistoryOfTrancsactions")]
    public class HistoryDbModel
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
    }
}
