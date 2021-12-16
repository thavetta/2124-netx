using ParserDemoLib.Models;

namespace ParserDemoLib.Parsers;

public interface IParser
{
    List<BaseModel> ZpracujFile(string fileName);
}