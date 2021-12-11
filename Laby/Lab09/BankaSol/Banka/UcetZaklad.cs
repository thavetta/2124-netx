namespace Banka;

public class UcetZaklad
{
    private static int dalsiUcet = 1;
    public UcetZaklad()
    {
        CisloUctu = dalsiUcet;
        dalsiUcet++;
    }
    public int CisloUctu { get; }

    protected string majitel = "Tajuplny";
    public string Majitel
    {
        get { return majitel; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException("majitel");
            majitel = value;
        }
    }
    public decimal Stav { get; protected set; }
    public StatusUctu Status { get; set; } = StatusUctu.Aktivny;

     public void Vklad(decimal castka)
    {
        if (this.Status != StatusUctu.Aktivny)
            throw new InvalidOperationException("Operacia na neaktivnom ucte");

        if (castka <= 0)
            throw new ArgumentOutOfRangeException(nameof(castka));

        this.Stav += castka;
        Console.WriteLine($"Na účet {CisloUctu} majitele {majitel} bylo vloženo {castka} a stav je {Stav}");
    }

    public void Vyber(decimal castka)
    {
        if (this.Status != StatusUctu.Aktivny)
            throw new InvalidOperationException("Operace na neaktím účtu není povolena");
        if (castka <= 0)
            throw new ArgumentOutOfRangeException(nameof(castka));

        if (this.Stav < castka)
            throw new InvalidOperationException("Nedostatečné krytí na účtu");

        this.Stav -= castka;
        Console.WriteLine($"Z účtu {CisloUctu} majitele {majitel} bylo vybráno {castka} a stav je {Stav}");
    }

    public override string ToString()
    {
        return majitel + " - " + Stav;
    }
}
