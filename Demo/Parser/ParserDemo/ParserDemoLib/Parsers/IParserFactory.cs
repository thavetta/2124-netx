namespace ParserDemoLib.Parsers;

public interface IParserFactory
{
    BaseParser VyberParser(string fileName);
}