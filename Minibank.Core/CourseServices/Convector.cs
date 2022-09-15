using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core
{
    public class Convector : IConvector
    {
        private readonly ICourse _course;

        public Convector(ICourse course)
        {
            _course = course;
        }
        public double Convert(double amount, string fromCurrency, string toCurrency)
        {
            var valueFromCurrency = _course.GetRubleCourse(fromCurrency);
            var valueToCurrency = _course.GetRubleCourse(toCurrency);

            var ratio = valueFromCurrency / valueToCurrency;

            return amount * ratio;
        }
    }
}