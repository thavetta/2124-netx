using ParserDemoLib.Models;
using TinyCsvParser.Mapping;

namespace ParserDemoLib.Maps;

/// <summary>
/// Pomocná třída definující mapu mezi csv strukturou a typem BetaModel
/// </summary>
public class BetaMap : CsvMapping<BetaModel>
{
    /// <summary>
    /// Konstruktor definující vazby
    /// </summary>
    public BetaMap()
    {
        MapProperty(0, x => x.Citatel);
        MapProperty(1, x => x.Jmenovatel);
        MapProperty(2, x => x.Majitel);
    }
}