# Lab 5

## Pouití metod

Cílem tohoto labu je nauèit se rozdìlovat kód do metod a pouívat je v programu.

Pøi vytvoøení projektu si vyzkoušíte i tvorbu Unit testù pro testování metod.

Na testování pomocí Unit testù existuje nìkolik frameworkù - v tomto pøípadì pouijeme [xUnit](xunit.net/).

### Pøíprava øešení

1. Vytvoøte si novı projekt typu Class Library. Název projektu bude `Cisla`. 
Název Solution zvolte napø. `CislaSol`.
1. V menu Tools najdìte monost NuGet Package Manager a zvolte `Package Manager Settings`.
1. V oknì Package Manager Settings zvolte `Package Sources` a pokud tam není, pøidejte novı zdroj s názvem `nuget.org` a adresou `https://api.nuget.org/v3/index.json`. Tím se umoní staení SW knihoven z centrálního úloištì.
1. Pøidejte do solution novı projekt typu Console Application. Název projektu bude `Matika2`.
1. Pøidejte do solution novı projekt typu xUnit Test Project. Název projektu bude `CislaTests`.

### Definice rozhraní

1. Pøidejte do projektu soubor s názvem `IVypocty.cs`. Pokud máte novou verzi dialogu kde zadáváte jen název, vznikne automaticky soubor podle šablony Interface.
Pokud máte klasické okno pro pøidání, vyberte typ dokumentu Interface.
1. Interface slouí k definici metod, kterou má tøída umìt pro své okolí. Doplòte do `IVypocty` následující pøedpisy metod:
	* `int NSD(int a, int b)` - metoda pro vıpoèet NSD
	* `int NSN(int a, int b)` - metoda pro vıpoèet NSN
	* `bool JePrvocislo(int a, int b)` - metoda pro zjištìní, zda je èíslo prvoèíslo
	* `int VstupCisla(string dotaz)` - metoda pro vstup èísla od uivatele
	* `int VstupCisla(StreamReader reader)` - metoda pro vstup èísla ze souboru èi jiného zdroje

	Vısledek by mìl vypadat takto.

		public interface IVypocty
		{
			int NSD(int a, int b);
			int NSN(int a, int b);
			int Faktorial(int a);
			bool JePrvocislo(int a);
			int VstupCisla(string dotaz);
			int VstupCisla(StreamReader reader);
		}

1. Vytvoøte tøídu `Pocitadlo` a implementujte rozhraní `IVypocty`. Kód by mìl vypadat takto:

		public class Pocitadlo : IVypocty
		{
		}

1. IVypocty bude èervenì podtrené. Kliknìte na nìj pravım tlaèítkem a zvolte `Implement Interface`.
1. Vısledkem by mìlo bıt (poøadí metod mùe bıt jinak):

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

1. Teï se pustíme do pøípravy testù, které pøi vıvoji pomohou rychle zjistit, zda metody fungují správnì.

### Pøíprava Unit testù

Unit testy jsou testy jednotlivıch metod. V tomto pøípadì budeme testovat metody z rozhraní `IVypocty`.
1. Pøejmenujte soubor `UnitTest1.cs` na `VypoctyTests.cs`. Dotaz na pøejmenování tøídy odsouhlaste.
1. Kliknìte pravım tlaèítkem na Dependencies v projektu `CislaTests` a zvolte `Add Project Reference`. Zaškrtnìte checkbox u projektu Cisla a potvrïte OK.
To umoní pøístup k typùm a metodám z projektu `Cisla` v testu.
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
        
    [Fact] je atribut, kterı oznaèuje metodu jako test. Vısledek testu je zelenı, pokud test prošel, èervenı pokud selhal.
    Název testu je vıznamnı, protoe se z nìj dá vysledovat, co test testuje. V tomto pøípadì testuje metodu NSD, která má platnı vstup a vısledek.

    Sekce Arrange testu slouí k pøípravì testovacích dat. Vytvoøím si instanci tøídy Pocitadlo a pøipravím si promìnné a a b tak, e vím, jaké je jejich NSD. Vısledek oèekávám 6.

    Sekce Act testu slouí k volání testované metody. Vısledek metody NSD uloím do promìnné vysledek.

    Sekce Assert testu slouí k porovnání vısledku s oèekávanım vısledkem. V tomto pøípadì pouívám metodu Assert.Equal, která porovná hodnoty dvou promìnnıch. Pokud se hodnoty rovnají, test prošel, jinak selhal.

1. V menu Test si najdìte Test Explorer a nechte ho zobrazit. 
1. V Test Exploreru kliknìte na tlaèítko Run All. Probìhne build projektu a spustí se testy. Vısledek bude samozøejmì neúspìšnı, protoe nemáme ještì naprogramovanou metodu NSD.
1. Ne se vrátíme k implementaci metody NSD, ještì si vytvoøíme testy pro další metody. Vytvoøte si testy pro metody NSN, Faktorial a JePrvocislo. Vısledek by mìl vypadat takto:

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
	
	Jak je vidìt, testy jsou velmi podobné. Všechny testy mají stejnou strukturu, jen se liší vstupními a oèekávanımi vıstupy.

1. Vyøešme ještì otázku spuštìní testù s více testovacími daty. To xUnit podporuje pomocí attributu `Theory` a `InlineData`. Upravte test NSD takto:

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

1. Najdìte si algoritmus z vıpoètu NSD v minulém cvièení. 
pouijte ji v metodì NSD v tøídì Pocitadlo. Vısledek by mìl vypadat takto:

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

1. Spuste test metody NSD a ovìøte, e teï u testy úspìšnì prošly.

### Implementace metody NSN

1. Vıpoèet NSN je dán vzorcem, take jej mùeme implementovat jednoduše. Vısledek by mìl vypadat takto:

		public int NSN(int a, int b)
		{
			return (a * b) / NSD(a, b);
		}

1. Otestujte vısledek podobnì jak u NSD.

### Implementace metody Faktorial

1. Vıpoèet faktoriálu je dán rekurzivním vzorcem F(n) = n * F(n-1) a víme e F(1) = 1, take jej mùeme implementovat jednoduše. Vısledek by mìl vypadat takto:

		public int Faktorial(int a)
        {
            if (a == 1)
                return 1;
            else
                return a * Faktorial(a - 1);
        }

1. Opìt otestujte e metoda vrací oèekávané vısledky.

### Implementace metody JePrvocislo

1. Prvoèíslo je èíslo, které je dìlitelné pouze jednièkou a sebou samım. Jednièka se za prvoèíslo nepovauje.
Z matematiky víme, e pokoušet se o dìlení staèí jen do odmocniny z daného èísla. To vıznamnì zjednoduší vıpoèet.
Dále mùeme algoritmu ulehèit práci, pokud hned na zaèátku vyøešíme sudá èísla. Jediné sudé èíslo které je zároveò prvoèíslem je 2.
1. První èást metody tak mùe vypadat takto:

		bool JePrvocislo(int a)
		{
			if (a == 2)
				return true;
			//Test zda je èíslo sudé (pomocí nultého bitu, ten je u sudıch èísel vdy 0)
			if ((a & 1) == 0)
				return false;
		}

1. Pro vıpoèet odmocniny z èísla mùeme pouít metodu `Math.Sqrt`. K testování dìlení se nejvíc hodí cyklus for.
Jako vylepšení staèí dìlit jen lichımi èísly, protoe sudá èísla jsme vyøešili vıše. 
Ještì upravíme název parametru a, na vhodnìjší `cislo`. Take celá metoda bude vypadat takto:

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

1. Teï mùete spustit všechny testy a ovìøit, e všechny testy prošly.

### Optimalizace kódu

1. Vıpoèet NSD je sice funkèní, ale extrémnì neefektivní, zejména pro velká èísla. Existuje mnohem lepší algoritmus, kterı je zaloen na zásadì, e NSD(a,b) = NSD(b,a % b). A vıpoèet se provádí tak dlouho, dokud modulo není nula. Pak je b vıslednım NSD. Take celá metoda NSD mùe vypadat takto:

		public int NSD(int a, int b)
		{
			int c; // pomocná promìnná pro prohození a a b
			while (b != 0)
			{
				c = a % b;
				a = b;
				b = c;
			}
			return a;
		}

1. Otestujte e všechny NSD testy stále prošly.

Tento postup má oficiální název **RGR => Red, Green, Refactor**. 
V prvním kroku se vytvoøí testy, které testují funkènost kódu. 
V druhém kroku se implementuje kód, kterı testy prochází. 
V posledním kroku se kód optimalizuje a zjednodušuje na základì vısledku testù nebo znalosti vıvojáøe.

### Kontrola vstupních parametrù

1. Všechny metody v tøídì `Pocitadlo` mají jako parametr èíslo typu int. Ale metody fungují v oboru tzv. pøirozenıch èísel. Take napø. u èísla -5 neplatí, e by se jednalo o prvoèíslo, protoe definice prvoèísla vyaduje, aby to bylo kladné celé èíslo vìtší ne 1.
1. Pro metodu `JePrvocislo` je tedy potøeba pøidat kontrolu, zda je èíslo vìtší ne 1. Tady se ale objeví nová otázka k rozhodnutí. Jaká chceme chování metody JePrvocislo pro èísla menší ne 2?
	* Jedna monost je vrátit `false`, tedy e 1, 0, -1, -2 atd. nejsou prvoèísla.
	* Druhá monost je vyvolat vıjimku, která bude oznaèovat, e byla zadána neplatná hodnota.

	Pozn. lektora: Osobnì v tìchto situacích preferuji vyvolání vıjimky a je pak vìcí toho, kdo metodu zavolal, zda ji odignoruje.
	
1. Zaèátek metody `JePrvocislo` by tak mohl vypadat takto:

		public bool JePrvocislo(int cislo)
        {
			if (cislo < 2)
				throw new ArgumentOutOfRangeException(nameof(cislo), "Zda je èíslo prvoèíslo lze urèit jen pro èísla vìtší ne 1");

1. Pro otestování chování, kdy ádoucí vısledek je vıjimka, je nutné udìlat novou test metodu.
její kód bude v tuto chvíli pro Vás malé woo-doo.
Ale všechno co potøebujete vìdìt je, e vıjimka je typu `ArgumentOutOfRangeException`.

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

	Assert.Throws je metoda, která oèekává, e bude vyvolána vıjimka v metodì, která je pøedána do metody jako parametr. 
	Tomu divnému vırazu se šipkou se øíká lambda vıraz a definuje se s ním tzv. delegát. O tom ještì bude na kurzu kapitola.

1. Nyní mùete spustit všechny testy a ovìøit, e všechny testy prošly.
1. Pøipravte principiálnì stejné testy pro metody `Faktorial`, `NSD` a `NSN`.
1. Ve stejném duchu mùete pøidat kontrolu, zda jsou vstupní parametry vìtší ne 0 i do metod `Faktorial`, `NSD` a `NSN`.

### Vstup èísel z klávesnice nebo streamu

1. Metody VratCislo mají umonit buï vstup uivatelem zadaného èísla, nebo vstup ze streamu.
1. Metoda VstupCisla která má parametr string, jsme naprogramovali v cvièení 4.2 a staèí jen zkopírovat a jemnì upravit u hotovı kód.

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
                    Console.WriteLine("zadané èíslo obsahuje neplatné znaky, zkuste to znovu.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("zadané èíslo je pøíliš velké, zkuste to znovu.");
                }
            }
            return cislo;
        }

1. Metoda VstupCisla která má parametr stream bude pouze pøevádìt obsah øádku na èíslo a budeme doufat e to bude fungovat.

        public int VstupCisla(StreamReader reader)
        {
            return int.Parse(reader.ReadLine());
        }

1. Testy k tìmto metodám teï dìlat nebudeme, tady je situace drobet sloitìjší.

### Pouití knihovny Cisla v consolové aplikaci Matika2

1. V projektu Matika2 kliknìte pravım tlaèítkem na `Dependencies` a vyberte volbu `Add Project Reference`.
1. V dialogu zaškrtnìte checkbox u projektu `Cisla`.
1. V Program.cs vytvoøte kód, kterım získáte od uivatele dvì èísla. K tìm mu spoèítáte a vypíšete NSD a NSN.
1. Dále si vyádáte od uivatele èíslo a vypíšete, zda je prvoèíslo.
1. Nakonec si vyádáte od uivatele èíslo a vypíšete jeho faktoriál.
1. Kód by mohl vypadat takto

		using Cisla;

		IVypocty vypocty = new Pocitadlo();

		int a = vypocty.VstupCisla("Zadejte první èíslo");
		int b = vypocty.VstupCisla("Zadejte druhé èíslo");

		Console.WriteLine($"NSD({a},{b})={vypocty.NSD(a,b)}");
		Console.WriteLine($"NSN({a},{b})={vypocty.NSN(a,b)}");

		int c = vypocty.VstupCisla("Zadejte èíslo pro zjištìní, zda je prvoèíslo");
		Console.WriteLine($"Je èíslo {c} prvoèíslo? {vypocty.JePrvocislo(c)}");

		int d = vypocty.VstupCisla("Zadejte èíslo pro vıpoèet faktoriálu");
		Console.WriteLine($"Faktoriál èísla {d} je {vypocty.Faktorial(d)}");

1. Nezapomeòte nastavit Matika2 ja StartUp projekt a spuste aplikaci a ovìøte, e vše funguje.

Jak vidíte, pøi programování se preferuje pouívání interface, kterı je vytvoøen pro danou úlohu.
Dále samotnı vıkonnı kód je zvykem dávat do knihoven, aby byl znovupouitelnı v jinıch projektech.
Pak lze jednoduše aplikovat testy, pro garanci e v knihovnì je kód správnì.
A pouití dobøe navrené knihovny je pak pøímoèaré a jednoduché.

A otázka na závìr:

**Jakı máte pocit z metod VstupCisla v interface Vypocty?**