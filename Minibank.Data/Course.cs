﻿using Minibank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Data
{
    public class Course : ICourse
    {
        public int Get()
        {
            return 60;
        }
    }
}