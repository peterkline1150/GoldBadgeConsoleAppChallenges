﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSixRepo
{
    public interface ICar
    {
        string Name { get; set; }
        int Weight { get; set; }
        double TopSpeed { get; set; }
    }
}
