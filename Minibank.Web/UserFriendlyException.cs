using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(string message) : base(message) { }
    }
}