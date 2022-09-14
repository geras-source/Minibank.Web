using Microsoft.AspNetCore.Mvc;
using Minibank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConvectorController : ControllerBase
    {
        private readonly IConvector _convector;

        public CurrencyConvectorController(IConvector convector)
        {
            _convector = convector;
        }
        [HttpGet]
        public double Get(double amount, string fromCurrency, string toCurrency)
        {
            if (amount >= 0)
            {
                var output = _convector.Convert(amount, fromCurrency, toCurrency);
                return output;
            }
            else
            {
                throw new ValidationException("Negative number");
            }
        }
    }
}