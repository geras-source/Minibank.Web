using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web
{
    public class ValidationException : System.ComponentModel.DataAnnotations.ValidationException
    {
        public ValidationException(string message) : base(message) { }
    }
}