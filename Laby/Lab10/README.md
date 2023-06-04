# Lab 10

## Z�klady vytv��en� instanc�

V tomto cvi�en� budeme definovat jednoduchou t��du s jedn�m konstruktorem. T��da bude reprezentovat osobu a bude dr�et informace jako ke jm�no, m�sto a plat.
V pokusn� aplikaci pak pro tuto t��du vytvo��me pole a to pole za r�zn�ch podm�nek budeme vypisovat.

### Vytvo�en� t��dy

1. Vytvo�te nov� projekt typu Class Library pro jazyk C# a pojmenujte jej `Osoby`.
1. P�ipraven� `Class1` p�ejmenujte na `Osoba`.
1. Vytvo�te automatick� vlastnosti pro id, jm�no, m�sto a plat typu long, string, string a int. Vlastnost pro id bude pouze ke �ten�.
1. Vytvo�te konstruktor, kter� bude m�t parametr pro id.
1. P�idejte metodu pro v�pis informac� o osob�. Metoda bude m�t standardn� n�zev `ToString` a bude vracet �et�zec.
1. V�sledn� k�d by mohl vypadat takto

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

### Vytvo�en� testovac� aplikace

1. P�idejte do solution dal�� projekt typu Console Application a pojmenujte jej `TestOsob`.
1. P�idejte referenci na projekt `Osoby`.
1. P�idejte do `Program.cs` tento k�d:

    ```csharp
    using Osoby;

    var seznam = VratSeznam();

    VypisOsoby(seznam);

    VypisOsoby(seznam.Where(o => o.Plat > 40000));
    ```

1. Vytvo�te metodu `VratSeznam`, kter� bude vracet pole osob. V metod� vytvo�te pole osob a napl�te jej n�kolika osobami.

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
1. P�idejte metodu pro v�pis osob ze seznamu

    ```csharp
	void VypisOsoby(IEnumerable<Osoba> osoby)
	{
		foreach (var osoba in osoby)
		{
			Console.WriteLine(osoba);
		}
	}
	```
1. Nastavte projekt `TestOsob` jako startup projekt a spus�te aplikaci. V�sledek by m�l vypadat takto:

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

### Ot�zky k zamy�len�

1. Pro� nen� parametr metody VypisOsob pole osob, ale IEnumerable<Osoba>?
1. Co za divn� z�pis je pou�it� pro v�pis osob s platem vy���m ne� 40000?
1. Pro� je v konstruktoru pou�it� parametr id, kdy� se nikde krom� v�pisu v ToString nepou��v�?