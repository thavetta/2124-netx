using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cisla
{
    public class Pocitadlo : IVypocty
    {
        public BigInteger Faktorial(BigInteger a)
        {
            if (a < 1)
                throw new ArgumentOutOfRangeException(nameof(a), "Faktoriál lze počítat jen pro kladná čísla");

            if (a == 1)
                return 1;
            else
                return a * Faktorial(a - 1);
        }

        public bool JePrvocislo(int cislo)
        {
            if (cislo < 2)
                throw new ArgumentOutOfRangeException(nameof(cislo), "Zda je číslo prvočíslo lze určit jen pro čísla větší než 1");
            if (cislo == 2)
                return true;
            if ((cislo & 1) == 0)
                return false;
            
            int limit = (int)Math.Sqrt(cislo) + 1;

            for (int delic = 3; delic < limit; delic += 2)
            {
                if (cislo % delic == 0)
                    return false;
            }
            
            return true;
        }

        public int NSD(int a, int b)
        {
            TestPrirozeneCisloMinimalne(a, 1);
            TestPrirozeneCisloMinimalne(b, 1);

            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }

        public int NSN(int a, int b)
        {
            return (a * b) / NSD(a, b);
        }

        public int VstupCisla(string dotaz)
        {
            int cislo;
            while (true)
            {
                try
                {
                    Console.WriteLine(dotaz);
                    cislo = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("zadané číslo obsahuje neplatné znaky, zkuste to znovu.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("zadané číslo je příliš velké, zkuste to znovu.");
                }
            }
            return cislo;
        }

        public int VstupCisla(StreamReader reader)
        {
            return int.Parse(reader.ReadLine());
        }

        private void TestPrirozeneCisloMinimalne(int cislo, int minimalni)
        {
            if (cislo < minimalni)
                throw new ArgumentOutOfRangeException(nameof(cislo), $"Číslo musí být větší nebo rovné jako {minimalni}");
        }
    }
}
