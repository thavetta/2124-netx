using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisla
{
    public class Pocitadlo : IVypocty
    {
        public int Faktorial(int a)
        {
            TestPrirozeneCisloMinimalne(a, 1);

            if (a == 1)
                return 1;
            else
                return a * Faktorial(a - 1);
        }

        public bool JePrvocislo(int cislo)
        {
            if (cislo < 2)
                throw new ArgumentOutOfRangeException(nameof(cislo), "Zda je číslo prvočíslo lze určit jen pro čísla větší než 1");
            //pokud je cislo 2, je prvočíslo. 2 je jediné sudé číslo, které je prvočíslo
            if (cislo == 2) 
                return true;
            //test pomocí bitové operace zjištění hodnoty v nejnižším bite, pokud je číslo sudé, není prvočíslo
            if ((cislo & 1) == 0)  
                return false;
            
            //určení limitu, po který je potřeba testovat dělení
            int limit = (int)Math.Sqrt(cislo) + 1; //bez +1 by test ve for cyklu musel být <=

            for (int delic = 3; delic < limit; delic += 2)
            {
                if (cislo % delic == 0)
                    return false;
            }
            //pokud se nenašel dělitel, je číslo prvočíslo
            return true;
        }

        public int[] VratPrvocisla(int maxCislo)
        {
            if (maxCislo < 2)
                throw new ArgumentOutOfRangeException("maxCislo", "parametr musí být větší než 1");
            //Eratostenovo sito
            // false - neškrtnuto, true - škrtnuto
            bool[] pole = new bool[maxCislo + 1];
            pole[0] = true;
            pole[1] = true;

            int limit = (int)Math.Sqrt(maxCislo) + 1;

            //Až po limit hledám zatím neškrtnutá čísla
            for (int cislo = 2; cislo < limit; cislo++)
            {
                //Pokud je číslo už škrtunté, jdu na další
                if (pole[cislo])
                    continue;

                //Vyškrtám všechny násobky neškrtnutého čísla, tedy škrtám od x+x až po konec
                for (int i = cislo * 2; i < pole.Length; i += cislo)
                {
                    pole[i] = true;
                }
            }
            //Priprava vysledneho pola prvocisel. Musím zjistit kolik těch prvočísel zůstalo
            int pocet = 0;
            foreach (bool item in pole)
            {
                if (!item)
                    pocet++;
            }

            int[] vysledek = new int[pocet];

            //Do vysledek potřebuji zapsat čísla odpovídající políčku s hodnotou false
            int index = 0; // slouží jako index do výsledného pole, abych věděl kam zapsat další prvočíslo
            for (int cislo = 0; cislo < pole.Length; cislo++)
            {
                if (!pole[cislo])
                {
                    vysledek[index] = cislo;
                    index++;
                }
            }

            return vysledek;
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


        private void TestPrirozeneCisloMinimalne(int cislo, int minimalni)
        {
            if (cislo < minimalni)
                throw new ArgumentOutOfRangeException(nameof(cislo), $"Číslo musí být větší nebo rovné jako {minimalni}");
        }
    }
}
