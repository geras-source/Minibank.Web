using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core
{
    public interface ICourse
    {
        double GetRubleCourse(string currencyCode);
    }
}