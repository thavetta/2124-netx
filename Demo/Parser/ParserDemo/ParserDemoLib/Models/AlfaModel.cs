namespace ParserDemoLib.Models;
/// <summary>
/// Model ALFA
/// </summary>
public class AlfaModel : BaseModel
{
    /// <summary>
    /// Vlastnost obsahující jméno
    /// </summary>
    public string? Jmeno { get; set; }
    
    /// <summary>
    /// Vlastnost město
    /// </summary>
    public string? Mesto { get; set; }
    
    /// <summary>
    /// Plat pracovníka
    /// </summary>
    public int Plat { get; set; }
    
    /// <summary>
    /// Metoda pro string reprezentaci záznamu
    /// </summary>
    /// <returns>vrací jméno - město - plat</returns>
    public override string ToString()
    {
        return Jmeno + " - " + Mesto + " - " + Plat;
    }
}