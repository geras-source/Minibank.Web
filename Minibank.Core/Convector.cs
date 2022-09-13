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
        public int Convert(int cash)
        {
            var value = _course.Get();

            return cash / value;
        }
    }
}