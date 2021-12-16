using ParserDemoLib.Parsers;

var seznam = Directory.GetFiles(".","*.csv");

IParserFactory factory = new ParserFactory();

foreach (string fileName in seznam)
{
    IParser parser = factory.VyberParser(fileName);
    var result = parser.ZpracujFile(fileName);

    foreach (var model in result)
    {
        Console.WriteLine(model);
    }

    Console.WriteLine("*************************");
}