using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarovky;

class Zarovka
{
    public string Jmeno { get; set; }

    private bool stav;

    public void ZmenaStavu()
    {
        stav = !stav;
        if (stav)
            Console.WriteLine("Zarovka " + Jmeno + " se rozsvitila");
        else
            Console.WriteLine("Zarovka " + Jmeno + " zhasla");
    }
}