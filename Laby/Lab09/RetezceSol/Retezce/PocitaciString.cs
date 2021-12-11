using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retazce
{
    public class PocitaciString
    {
        public string Retezec { get; set; }

        public int this[char znak]
        {
            get
            {
                int pocet = 0;
                foreach (char item in Retezec)
                {
                    if (item == znak)
                        pocet++;
                }
                return pocet;
            }
        }

        public char this[int index]
        {
            get { return Retezec[index]; }
        }
    }
}
