# Lab 5

## Použití metod

Cílem tohoto labu je naučit se rozdělovat kód do metod a používat je v programu.

Při vytvoření projektu si vyzkoušíte i tvorbu Unit testů pro testování metod.

Na testování pomocí Unit testů existuje několik frameworků - v tomto případě použijeme [xUnit](xunit.net/).

### Příprava řešení

1. Vytvořte si nový projekt typu Class Library. Název projektu bude `Cisla`. 
Název Solution zvolte např. `CislaSol`.
1. V menu Tools najděte možnost NuGet Package Manager a zvolte `Package Manager Settings`.
1. V okně Package Manager Settings zvolte `Package Sources` a pokud tam není, přidejte nový zdroj s názvem `nuget.org` a adresou `https://api.nuget.org/v3/index.json`. Tím se umožní stažení SW knihoven z centrálního úložiště.
1. Přidejte do solution nový projekt typu Console Application. Název projektu bude `Matika2`.
1. Přidejte do solution nový projekt typu xUnit Test Project. Název projektu bude `CislaTests`.

### Definice rozhraní

1. Přidejte do projektu `Cisla` soubor s názvem `IVypocty.cs`. Pokud máte novou verzi dialogu kde zadáváte jen název, vznikne automaticky soubor podle šablony Interface.
Pokud máte klasické okno pro přidání, vyberte typ dokumentu Interface.
1. Interface slouží k definici metod, kterou má třída umět pro své okolí. Doplňte do `IVypocty` následující předpisy metod:
	* `int NSD(int a, int b)` - metoda pro výpočet NSD
	* `int NSN(int a, int b)` - metoda pro výpočet NSN
 	* `int Faktorial(int a)` - metoda pro výpočet faktoriálu daného čísla (a!)
	* `bool JePrvocislo(int a)` - metoda pro zjištění, zda je číslo prvočíslo
	* `int VstupCisla(string dotaz)` - metoda pro vstup čísla od uživatele
	* `int VstupCisla(StreamReader reader)` - metoda pro vstup čísla ze souboru či jiného zdroje

	Výsledek by měl vypadat takto.

		public interface IVypocty
		{
			int NSD(int a, int b);
			int NSN(int a, int b);
			int Faktorial(int a);
			bool JePrvocislo(int a);
			int VstupCisla(string dotaz);
			int VstupCisla(StreamReader reader);
		}

1. Vytvořte třídu `Pocitadlo` a implementujte rozhraní `IVypocty`. Kód by měl vypadat takto:

		public class Pocitadlo : IVypocty
		{
		}

1. IVypocty bude červeně podtržené. Klikněte na něj pravým tlačítkem a zvolte `Implement Interface`.
1. Výsledkem by mělo být (pořadí metod může být jinak):

        public class Pocitadlo : IVypocty
        {
            public int Faktorial(int a)
            {
                throw new NotImplementedException();
            }

            public bool JePrvocislo(int a)
            {
                throw new NotImplementedException();
            }

            public int NSD(int a, int b)
            {
                throw new NotImplementedException();
            }

            public int NSN(int a, int b)
            {
                throw new NotImplementedException();
            }

            public int VstupCisla(string dotaz)
            {
                throw new NotImplementedException();
            }

            public int VstupCisla(StreamReader reader)
            {
                throw new NotImplementedException();
            }
        }

1. Teď se pustíme do přípravy testů, které při vývoji pomohou rychle zjistit, zda metody fungují správně.

### Příprava Unit testů

Unit testy jsou testy jednotlivých metod. V tomto případě budeme testovat metody z rozhraní `IVypocty`.
1. Přejmenujte soubor `UnitTest1.cs` na `VypoctyTests.cs`. Dotaz na přejmenování třídy odsouhlaste.
1. Klikněte pravým tlačítkem na Dependencies v projektu `CislaTests` a zvolte `Add Project Reference`. Zaškrtněte checkbox u projektu Cisla a potvrďte OK.
To umožní přístup k typům a metodám z projektu `Cisla` v testu.
1. Upravte obsah souboru `VypoctyTests.cs` takto:

        using Cisla;
        namespace CislaTests;

        public class VypoctyTests
        {
            [Fact]
            public void NSD_PlatnyVstup_Vysledek()
            {
                //Arange
                IVypocty vypocty = new Pocitadlo();
                int a = 24;
                int b = 18;
                int ocekavam = 6;
                //Act
                int vysledek = vypocty.NSD(a, b);
                //Assert
                Assert.Equal(ocekavam, vysledek);
            }
        }
        
    [Fact] je atribut, který označuje metodu jako test. Výsledek testu je zelený, pokud test prošel, červený pokud selhal.
    Název testu je významný, protože se z něj dá vysledovat, co test testuje. V tomto případě testuje metodu NSD, která má platný vstup a výsledek.

    Sekce Arrange testu slouží k přípravě testovacích dat. Vytvořím si instanci třídy Pocitadlo a připravím si proměnné a a b tak, že vím, jaké je jejich NSD. Výsledek očekávám 6.

    Sekce Act testu slouží k volání testované metody. Výsledek metody NSD uložím do proměnné vysledek.

    Sekce Assert testu slouží k porovnání výsledku s očekávaným výsledkem. V tomto případě používám metodu Assert.Equal, která porovná hodnoty dvou proměnných. Pokud se hodnoty rovnají, test prošel, jinak selhal.

1. V menu Test si najděte Test Explorer a nechte ho zobrazit. 
1. V Test Exploreru klikněte na tlačítko Run All. Proběhne build projektu a spustí se testy. Výsledek bude samozřejmě neúspěšný, protože nemáme ještě naprogramovanou metodu NSD.
1. Než se vrátíme k implementaci metody NSD, ještě si vytvoříme testy pro další metody. Vytvořte si testy pro metody NSN, Faktorial a JePrvocislo. Výsledek by měl vypadat takto:

		[Fact]
		public void NSN_PlatnyVstup_Vysledek()
		{
			//Arange
			IVypocty vypocty = new Pocitadlo();
			int a = 24;
			int b = 18;
			int ocekavam = 72;
			//Act
			int vysledek = vypocty.NSN(a, b);
			//Assert
			Assert.Equal(ocekavam, vysledek);
		}

		[Fact]
		public void Faktorial_PlatnyVstup_Vysledek()
		{
			//Arange
			IVypocty vypocty = new Pocitadlo();
			int a = 5;
			int ocekavam = 120;
			//Act
			int vysledek = vypocty.Faktorial(a);
			//Assert
			Assert.Equal(ocekavam, vysledek);
		}

		[Fact]
		public void JePrvocislo_PlatnyVstup_Vysledek()
		{
			//Arange
			IVypocty vypocty = new Pocitadlo();
			int a = 5;
			bool ocekavam = true;
			//Act
			bool vysledek = vypocty.JePrvocislo(a);
			//Assert
			Assert.Equal(ocekavam, vysledek);
		}
	
	Jak je vidět, testy jsou velmi podobné. Všechny testy mají stejnou strukturu, jen se liší vstupními a očekávanými výstupy.

1. Vyřešme ještě otázku spuštění testů s více testovacími daty. To xUnit podporuje pomocí attributu `Theory` a `InlineData`. Upravte test NSD takto:

		[Theory]
        [InlineData(24, 18, 6)]
        [InlineData(24, 36, 12)]
        [InlineData(29, 6, 1)]
        public void NSD_PlatnyVstup_Vysledek(int a, int b, int ocekavam)
        {
            //Arange
            IVypocty vypocty = new Pocitadlo();
            //Act
            int vysledek = vypocty.NSD(a, b);
            //Assert
            Assert.Equal(ocekavam, vysledek);
        }

1. Ve stejném duchu upravte i další testy.

### Implementace metody NSD

1. Najděte si algoritmus z výpočtu NSD v minulém cvičení. 
použijte ji v metodě NSD v třídě Pocitadlo. Výsledek by měl vypadat takto:

		public int NSD(int a, int b)
		{
			while (a != b)
			{
				if (a > b)
					a -= b;
				else
					b -= a;
			}
			return a;
		}

1. Spusťte test metody NSD a ověřte, že teď už testy úspěšně prošly.

### Implementace metody NSN

1. Výpočet NSN je dán vzorcem, takže jej můžeme implementovat jednoduše. Výsledek by měl vypadat takto:

		public int NSN(int a, int b)
		{
			return (a * b) / NSD(a, b);
		}

1. Otestujte výsledek podobně jak u NSD.

### Implementace metody Faktorial

1. Výpočet faktoriálu je dán rekurzivním vzorcem F(n) = n * F(n-1) a víme že F(1) = 1, takže jej můžeme implementovat jednoduše. Výsledek by měl vypadat takto:

		public int Faktorial(int a)
        {
            if (a == 1)
                return 1;
            else
                return a * Faktorial(a - 1);
        }

1. Opět otestujte že metoda vrací očekávané výsledky.

### Implementace metody JePrvocislo

1. Prvočíslo je číslo, které je dělitelné pouze jedničkou a sebou samým. Jednička se za prvočíslo nepovažuje.
Z matematiky víme, že pokoušet se o dělení stačí jen do odmocniny z daného čísla. To významně zjednoduší výpočet.
Dále můžeme algoritmu ulehčit práci, pokud hned na začátku vyřešíme sudá čísla. Jediné sudé číslo které je zároveň prvočíslem je 2.
1. První část metody tak může vypadat takto:

		bool JePrvocislo(int a)
		{
			if (a == 2)
				return true;
			//Test zda je číslo sudé (pomocí nultého bitu, ten je u sudých čísel vždy 0)
			if ((a & 1) == 0)
				return false;
		}

1. Pro výpočet odmocniny z čísla můžeme použít metodu `Math.Sqrt`. K testování dělení se nejvíc hodí cyklus for.
Jako vylepšení stačí dělit jen lichými čísly, protože sudá čísla jsme vyřešili výše. 
Ještě upravíme název parametru a, na vhodnější `cislo`. Takže celá metoda bude vypadat takto:

		public bool JePrvocislo(int cislo)
        {
            if (cislo == 2)
                return true;
            if ((cislo & 1) == 0)
                return false;
            
            int limit = (int)Math.Sqrt(cislo);

            for (int delic = 3; delic < limit; delic += 2)
            {
                if (cislo % delic == 0)
                    return false;
            }
            
            return true;
        }

1. Teď můžete spustit všechny testy a ověřit, že všechny testy prošly.

### Optimalizace kódu

1. Výpočet NSD je sice funkční, ale extrémně neefektivní, zejména pro velká čísla. Existuje mnohem lepší algoritmus, který je založen na zásadě, že NSD(a,b) = NSD(b,a % b). A výpočet se provádí tak dlouho, dokud modulo není nula. Pak je b výsledným NSD. Takže celá metoda NSD může vypadat takto:

		public int NSD(int a, int b)
		{
			int c; // pomocná proměnná pro prohození a a b
			while (b != 0)
			{
				c = a % b;
				a = b;
				b = c;
			}
			return a;
		}

1. Otestujte že všechny NSD testy stále prošly.

Tento postup má oficiální název **RGR => Red, Green, Refactor**. 
V prvním kroku se vytvoří testy, které testují funkčnost kódu. 
V druhém kroku se implementuje kód, který testy prochází. 
V posledním kroku se kód optimalizuje a zjednodušuje na základě výsledku testů nebo znalosti vývojáře.

### Kontrola vstupních parametrů

1. Všechny metody v třídě `Pocitadlo` mají jako parametr číslo typu int. Ale metody fungují v oboru tzv. přirozených čísel. Takže např. u čísla -5 neplatí, že by se jednalo o prvočíslo, protože definice prvočísla vyžaduje, aby to bylo kladné celé číslo větší než 1.
1. Pro metodu `JePrvocislo` je tedy potřeba přidat kontrolu, zda je číslo větší než 1. Tady se ale objeví nová otázka k rozhodnutí. Jaká chceme chování metody JePrvocislo pro čísla menší než 2?
	* Jedna možnost je vrátit `false`, tedy že 1, 0, -1, -2 atd. nejsou prvočísla.
	* Druhá možnost je vyvolat výjimku, která bude označovat, že byla zadána neplatná hodnota.

	Pozn. lektora: Osobně v těchto situacích preferuji vyvolání výjimky a je pak věcí toho, kdo metodu zavolal, zda ji odignoruje.
	
1. Začátek metody `JePrvocislo` by tak mohl vypadat takto:

		public bool JePrvocislo(int cislo)
        {
			if (cislo < 2)
				throw new ArgumentOutOfRangeException(nameof(cislo), "Zda je číslo prvočíslo lze určit jen pro čísla větší než 1");

1. Pro otestování chování, kdy žádoucí výsledek je výjimka, je nutné udělat novou test metodu.
její kód bude v tuto chvíli pro Vás malé woo-doo.
Ale všechno co potřebujete vědět je, že výjimka je typu `ArgumentOutOfRangeException`.

		[Theory]
		[InlineData(-5)]
		[InlineData(1)]
		public void JePrvocislo_NeplatnyVstup_Vyjimka(int a)
		{
			//Arange
			IVypocty vypocty = new Pocitadlo();
			//Act
        
			//Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => vypocty.JePrvocislo(a));
		}

	Assert.Throws je metoda, která očekává, že bude vyvolána výjimka v metodě, která je předána do metody jako parametr. 
	Tomu divnému výrazu se šipkou se říká lambda výraz a definuje se s ním tzv. delegát. O tom ještě bude na kurzu kapitola.

1. Nyní můžete spustit všechny testy a ověřit, že všechny testy prošly.
1. Připravte principiálně stejné testy pro metody `Faktorial`, `NSD` a `NSN`.
1. Ve stejném duchu můžete přidat kontrolu, zda jsou vstupní parametry větší než 0 i do metod `Faktorial`, `NSD` a `NSN`.

### Vstup čísel z klávesnice nebo streamu

1. Metody VratCislo mají umožnit buď vstup uživatelem zadaného čísla, nebo vstup ze streamu.
1. Metoda VstupCisla která má parametr string, jsme naprogramovali v cvičení 4.2 a stačí jen zkopírovat a jemně upravit už hotový kód.

        public int VstupCisla(string dotaz)
        {
            int cislo;
            while (true)
            {
                try
                {
                    Console.WriteLine(dotaz);
                    cislo = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("zadané číslo obsahuje neplatné znaky, zkuste to znovu.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("zadané číslo je příliš velké, zkuste to znovu.");
                }
            }
            return cislo;
        }

1. Metoda VstupCisla která má parametr stream bude pouze převádět obsah řádku na číslo a budeme doufat že to bude fungovat.

        public int VstupCisla(StreamReader reader)
        {
            return int.Parse(reader.ReadLine());
        }

1. Testy k těmto metodám teď dělat nebudeme, tady je situace drobet složitější.

### Použití knihovny Cisla v consolové aplikaci Matika2

1. V projektu Matika2 klikněte pravým tlačítkem na `Dependencies` a vyberte volbu `Add Project Reference`.
1. V dialogu zaškrtněte checkbox u projektu `Cisla`.
1. V Program.cs vytvořte kód, kterým získáte od uživatele dvě čísla. K těm mu spočítáte a vypíšete NSD a NSN.
1. Dále si vyžádáte od uživatele číslo a vypíšete, zda je prvočíslo.
1. Nakonec si vyžádáte od uživatele číslo a vypíšete jeho faktoriál.
1. Kód by mohl vypadat takto

		using Cisla;

		IVypocty vypocty = new Pocitadlo();

		int a = vypocty.VstupCisla("Zadejte první číslo");
		int b = vypocty.VstupCisla("Zadejte druhé číslo");

		Console.WriteLine($"NSD({a},{b})={vypocty.NSD(a,b)}");
		Console.WriteLine($"NSN({a},{b})={vypocty.NSN(a,b)}");

		int c = vypocty.VstupCisla("Zadejte číslo pro zjištění, zda je prvočíslo");
		Console.WriteLine($"Je číslo {c} prvočíslo? {vypocty.JePrvocislo(c)}");

		int d = vypocty.VstupCisla("Zadejte číslo pro výpočet faktoriálu");
		Console.WriteLine($"Faktoriál čísla {d} je {vypocty.Faktorial(d)}");

1. Nezapomeňte nastavit Matika2 ja StartUp projekt a spusťte aplikaci a ověřte, že vše funguje.

Jak vidíte, při programování se preferuje používání interface, který je vytvořen pro danou úlohu.
Dále samotný výkonný kód je zvykem dávat do knihoven, aby byl znovupoužitelný v jiných projektech.
Pak lze jednoduše aplikovat testy, pro garanci že v knihovně je kód správně.
A použití dobře navržené knihovny je pak přímočaré a jednoduché.

A otázka na závěr:

**Jaký máte pocit z metod VstupCisla v interface Vypocty?**
