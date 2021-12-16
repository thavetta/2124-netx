using ParserDemoLib.Models;

namespace ParserDemoLib.Parsers;

public abstract class BaseParser
{
    public List<BaseModel> ZpracujFile(string fileName)
    {
        return NactiData(fileName, DateTime.Now);
    }

    protected abstract List<BaseModel> NactiData(string fileName, DateTime cas);
}