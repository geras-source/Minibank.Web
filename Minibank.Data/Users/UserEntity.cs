using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Data.Users
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
