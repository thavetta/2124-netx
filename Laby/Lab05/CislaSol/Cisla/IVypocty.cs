﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cisla;

public interface IVypocty
{
    int NSD(int a, int b);
    int NSN(int a, int b);
    BigInteger Faktorial(BigInteger a);
    bool JePrvocislo(int a);
    int VstupCisla(string dotaz);
    int VstupCisla(StreamReader reader);
}