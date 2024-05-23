namespace Banka;

public class UcetZaklad 
{
    private decimal stav;
    private string majitel;
    private StatusUctu status = StatusUctu.Aktivny;

    public void NastavMajitele(string majitel)
    {
        if (string.IsNullOrWhiteSpace(majitel))
            throw new ArgumentException("Jmeno majitele musí obsahovat viditelné znaky");

        this.majitel = majitel;
    }

    public string VratMajitele()
    {
        return this.majitel;
    }

    public decimal VratStav()
    {
        return this.stav;
    }

    public void Vklad(decimal castka)
    {
        if (this.status != StatusUctu.Aktivny)
            throw new InvalidOperationException("Operacia na neaktivnom ucte");

        this.stav += castka;
        Console.WriteLine("Na účet majitele {0} bylo vloženo {1} a stav je {2}", this.majitel, castka, this.stav);
    }

    public void Vyber(decimal castka)
    {
        if (this.status != StatusUctu.Aktivny)
            throw new InvalidOperationException("Operace na neaktím účtu není povolena");

        if (this.stav < castka)
            throw new InvalidOperationException("Nedostatečné krytí na účtu");

        this.stav -= castka;
        Console.WriteLine("Z účtu majitele {0} bylo vybráno {1} a stav je {2}",
            this.majitel, castka, this.stav);
    }

    public override string ToString()
    {
        return majitel + " - " + stav;
    }
}
