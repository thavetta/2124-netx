using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisla;

public interface IVypocty
{
    int NSD(int a, int b);
    int NSN(int a, int b);
    int Faktorial(int a);
    bool JePrvocislo(int a);
    int[] VratPrvocisla(int maxCislo);
}