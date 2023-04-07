using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserDemoLib.Models;
/// <summary>
/// Základ pro jakýkoliv Model v aplikaci
/// </summary>
public abstract class BaseModel
{
    /// <summary>
    /// Určuje okamžik vytvoření záznamu
    /// </summary>
    public DateTime Vytvoreno { get; set; }
}
