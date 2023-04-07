namespace ParserDemoLib.Models;
/// <summary>
/// Model BETA
/// </summary>
public class BetaModel : BaseModel
{
    /// <summary>
    /// Vlastnost čitatel
    /// </summary>
    public int Citatel { get; set; }

    /// <summary>
    /// Vlastnost jmenovatel
    /// </summary>
    public int Jmenovatel { get; set; }

    /// <summary>
    /// Vlastnost majitel zlomku
    /// </summary>
    public string? Majitel { get; set; }

    /// <summary>
    /// Realizuje převod na řetězec
    /// </summary>
    /// <returns>vrací majitele a k němu zadaný zlomek</returns>
    public override string ToString()
    {
        return Majitel + " - " + Citatel + "/" + Jmenovatel;
    }
}