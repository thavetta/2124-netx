namespace ParserDemoLib.Parsers;

/// <summary>
/// Třída pro určení typu parseru.
/// Na základě vstupních dat vybere správný typ parseru
/// </summary>
public class ParserFactory : IParserFactory
{
    /// <summary>
    /// Metoda má za úkol podle názvu souboru vybrat odpovídající parser.
    /// V ukázkovém případě je typ dán začátkem názvu souboru po znak '-'
    /// </summary>
    /// <param name="fileName">název souboru pro zpracování</param>
    /// <returns>konkrétní parser pro daný soubor</returns>
    /// <exception cref="ArgumentException">Název souboru je null nebo neobsahuje viditelné znaky</exception>
    /// <exception cref="FileNotFoundException">Uvedený soubor neexistuje na disku</exception>
    /// <exception cref="InvalidOperationException">Název souboru neobsahuje správné určení typu</exception>
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