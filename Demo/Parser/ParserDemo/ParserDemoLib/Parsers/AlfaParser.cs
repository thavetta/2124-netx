using System.Text;
using ParserDemoLib.Maps;
using ParserDemoLib.Models;
using TinyCsvParser;

namespace ParserDemoLib.Parsers;

public class AlfaParser : BaseParser
{
    protected override List<BaseModel> NactiData(string fileName, DateTime cas)
    {
        CsvParserOptions options = new(true, ';');
        AlfaMap mapa = new();
        CsvParser<AlfaModel> parser = new(options, mapa);

        var query = parser.ReadFromFile(fileName, Encoding.UTF8);

        List<BaseModel> vysledek = new();

        foreach (var zaznam in query)
        {
            if (!zaznam.IsValid)
                continue;

            zaznam.Result.Vytvoreno = cas;
            vysledek.Add(zaznam.Result);
        }
        
        return vysledek;
    }
}