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
        public int Get(int currency)
        {
            if (currency >= 0)
            {
                var output = _convector.Convert(currency);
                return output;
            }
            else
            {
                throw new UserFriendlyException("Negative number");
            }
        }
    }
}