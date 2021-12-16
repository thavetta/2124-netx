using ParserDemoLib.Parsers;

var seznam = Directory.GetFiles(".","*.csv");

var factory = new ParserFactory();

foreach (string fileName in seznam)
{
    var parser = factory.VyberParser(fileName);
    var result = parser.ZpracujFile(fileName);

    foreach (var model in result)
    {
        Console.WriteLine(model);
    }

    Console.WriteLine("*************************");
}