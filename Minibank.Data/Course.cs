using Minibank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Data
{
    public class Course : ICourse
    {
        private readonly Random _random;
        public Course()
        {
            _random = new Random();
        }
        public int Get()
        {
            return _random.Next();
        }
    }
}