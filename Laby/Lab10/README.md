# Lab 10

## Základy vytváøení instancí

V tomto cvièení budeme definovat jednoduchou tøídu s jedním konstruktorem. Tøída bude reprezentovat osobu a bude dret informace jako ke jméno, mìsto a plat.
V pokusné aplikaci pak pro tuto tøídu vytvoøíme pole a to pole za rùznıch podmínek budeme vypisovat.

### Vytvoøení tøídy

1. Vytvoøte novı projekt typu Class Library pro jazyk C# a pojmenujte jej `Osoby`.
1. Pøipravenı `Class1` pøejmenujte na `Osoba`.
1. Vytvoøte automatické vlastnosti pro id, jméno, mìsto a plat typu long, string, string a int. Vlastnost pro id bude pouze ke ètení.
1. Vytvoøte konstruktor, kterı bude mít parametr pro id.
1. Pøidejte metodu pro vıpis informací o osobì. Metoda bude mít standardní název `ToString` a bude vracet øetìzec.
1. Vıslednı kód by mohl vypadat takto

```csharp
public class Osoba
{
    public long Id { get;}
    public string Jmeno { get; set; }
    public string Mesto { get; set; }
    public int Plat { get; set; }

    public Osoba(long id)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"{Id} - {Jmeno} - {Mesto}";
    }
}
```

### Vytvoøení testovací aplikace

1. Pøidejte do solution další projekt typu Console Application a pojmenujte jej `TestOsob`.
1. Pøidejte referenci na projekt `Osoby`.
1. Pøidejte do `Program.cs` tento kód:

    ```csharp
    using Osoby;

    var seznam = VratSeznam();

    VypisOsoby(seznam);

    VypisOsoby(seznam.Where(o => o.Plat > 40000));
    ```

1. Vytvoøte metodu `VratSeznam`, která bude vracet pole osob. V metodì vytvoøte pole osob a naplòte jej nìkolika osobami.

    ```csharp
    Osoba[] VratSeznam()
    {
        return new[]
        {
            new Osoba(1) { Jmeno = "Tomas", Mesto = "Brno", Plat = 40000 },
            new Osoba(2) { Jmeno = "Jana", Mesto = "Ostrava", Plat = 45000 },
            new Osoba(3) { Jmeno = "Karel", Mesto = "Plzen", Plat = 38000 },
            new Osoba(4) { Jmeno = "Ondrej", Mesto = "Poprad", Plat = 44000 },
            new Osoba(5) { Jmeno = "Eva", Mesto = "Liberec", Plat = 41000 },
        };
    }
    ```
1. Pøidejte metodu pro vıpis osob ze seznamu

    ```csharp
	void VypisOsoby(IEnumerable<Osoba> osoby)
	{
		foreach (var osoba in osoby)
		{
			Console.WriteLine(osoba);
		}
	}
	```
1. Nastavte projekt `TestOsob` jako startup projekt a spuste aplikaci. Vısledek by mìl vypadat takto:

	```
	1 - Tomas - Brno
	2 - Jana - Ostrava
	3 - Karel - Plzen
	4 - Ondrej - Poprad
	5 - Eva - Liberec
	2 - Jana - Ostrava
	4 - Ondrej - Poprad
	5 - Eva - Liberec
	```

### Otázky k zamyšlení

1. Proè není parametr metody VypisOsob pole osob, ale IEnumerable<Osoba>?
1. Co za divnı zápis je pouitı pro vıpis osob s platem vyšším ne 40000?
1. Proè je v konstruktoru pouitı parametr id, kdy se nikde kromì vıpisu v ToString nepouívá?