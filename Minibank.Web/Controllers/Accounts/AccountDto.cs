using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web.Controllers.Accounts
{
    public class AccountDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Currency { get; set; }
    }
}
