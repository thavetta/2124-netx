namespace ParserDemoLib.Parsers;

public class ParserFactory
{
    public BaseParser VyberParser(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("Nekorektni nazev souboru");

        if (!File.Exists(fileName))
            throw new FileNotFoundException("Soubor " + fileName + " na disku není");

        string name = Path.GetFileNameWithoutExtension(fileName);

        int pozice = name.IndexOf('-');

        string typ = name.Substring(0, pozice);

        switch (typ.ToLower())
        {
            case "alfa":
                return new AlfaParser();
            case "beta":
                return new BetaParser();
            default:
                throw new InvalidOperationException("Neznámý typ parseru");
        }
    }
}