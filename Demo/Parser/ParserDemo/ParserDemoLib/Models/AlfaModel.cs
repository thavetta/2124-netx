using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserDemoLib.Models;

public class AlfaModel : BaseModel
{
    public string? Jmeno { get; set; }
    public string? Mesto { get; set; }
    public int Plat { get; set; }

    public override string ToString()
    {
        return Jmeno + " - " + Mesto + " - " + Plat;
    }
}