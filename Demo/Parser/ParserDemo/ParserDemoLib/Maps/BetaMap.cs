using ParserDemoLib.Models;
using TinyCsvParser.Mapping;

namespace ParserDemoLib.Maps;

public class BetaMap : CsvMapping<BetaModel>
{
    public BetaMap()
    {
        MapProperty(0, x => x.Citatel);
        MapProperty(1, x => x.Jmenovatel);
        MapProperty(2, x => x.Majitel);
    }
}