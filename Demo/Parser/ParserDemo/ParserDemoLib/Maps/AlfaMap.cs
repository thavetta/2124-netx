using ParserDemoLib.Models;
using TinyCsvParser.Mapping;

namespace ParserDemoLib.Maps;

/// <summary>
/// Pomocná třída definující mapu mezi csv strukturou a typem AlfaModel
/// </summary>
public class AlfaMap : CsvMapping<AlfaModel>
{
    /// <summary>
    /// Konstruktor definující vazby
    /// </summary>
    public AlfaMap()
    {
        MapProperty(0, x => x.Jmeno);
        MapProperty(1, x => x.Mesto);
        MapProperty(2, x => x.Plat);
    }
    
}