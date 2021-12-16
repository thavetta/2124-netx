namespace ParserDemoLib.Models;

public class BetaModel : BaseModel
{
    public int Citatel { get; set; }
    public int Jmenovatel { get; set; }
    public string? Majitel { get; set; }

    public override string ToString()
    {
        return Majitel + " - " + Citatel + "/" + Jmenovatel;
    }
}