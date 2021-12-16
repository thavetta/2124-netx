using ParserDemoLib.Models;
using TinyCsvParser.Mapping;

namespace ParserDemoLib.Maps;

public class AlfaMap : CsvMapping<AlfaModel>
{
    public AlfaMap()
    {
        MapProperty(0, x => x.Jmeno);
        MapProperty(1, x => x.Mesto);
        MapProperty(2, x => x.Plat);
    }
    
}