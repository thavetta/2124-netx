# Lab 5

## Pou�it� metod

C�lem tohoto labu je nau�it se rozd�lovat k�d do metod a pou��vat je v programu.

P�i vytvo�en� projektu si vyzkou��te i tvorbu Unit test� pro testov�n� metod.

Na testov�n� pomoc� Unit test� existuje n�kolik framework� - v tomto p��pad� pou�ijeme [xUnit](xunit.net/).

### P��prava �e�en�

1. Vytvo�te si nov� projekt typu Class Library. N�zev projektu bude `Cisla`. 
N�zev Solution zvolte nap�. `CislaSol`.
1. V menu Tools najd�te mo�nost NuGet Package Manager a zvolte `Package Manager Settings`.
1. V okn� Package Manager Settings zvolte `Package Sources` a pokud tam nen�, p�idejte nov� zdroj s n�zvem `nuget.org` a adresou `https://api.nuget.org/v3/index.json`. T�m se umo�n� sta�en� SW knihoven z centr�ln�ho �lo�i�t�.
1. P�idejte do solution nov� projekt typu Console Application. N�zev projektu bude `Matika2`.
1. P�idejte do solution nov� projekt typu xUnit Test Project. N�zev projektu bude `CislaTests`.

### Definice rozhran�

1. P�idejte do projektu soubor s n�zvem `IVypocty.cs`. Pokud m�te novou verzi dialogu kde zad�v�te jen n�zev, vznikne automaticky soubor podle �ablony Interface.
Pokud m�te klasick� okno pro p�id�n�, vyberte typ dokumentu Interface.
1. Interface slou�� k definici metod, kterou m� t��da um�t pro sv� okol�. Dopl�te do `IVypocty` n�sleduj�c� p�edpisy metod:
	* `int NSD(int a, int b)` - metoda pro v�po�et NSD
	* `int NSN(int a, int b)` - metoda pro v�po�et NSN
	* `bool JePrvocislo(int a, int b)` - metoda pro zji�t�n�, zda je ��slo prvo��slo
	* `int VstupCisla(string dotaz)` - metoda pro vstup ��sla od u�ivatele
	* `int VstupCisla(StreamReader reader)` - metoda pro vstup ��sla ze souboru �i jin�ho zdroje

	V�sledek by m�l vypadat takto.

		public interface IVypocty
		{
			int NSD(int a, int b);
			int NSN(int a, int b);
			int Faktorial(int a);
			bool JePrvocislo(int a);
			int VstupCisla(string dotaz);
			int VstupCisla(StreamReader reader);
		}

1. Vytvo�te t��du `Pocitadlo` a implementujte rozhran� `IVypocty`. K�d by m�l vypadat takto:

		public class Pocitadlo : IVypocty
		{
		}

1. IVypocty bude �erven� podtr�en�. Klikn�te na n�j prav�m tla��tkem a zvolte `Implement Interface`.
1. V�sledkem by m�lo b�t (po�ad� metod m��e b�t jinak):

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

1. Te� se pust�me do p��pravy test�, kter� p�i v�voji pomohou rychle zjistit, zda metody funguj� spr�vn�.

### P��prava Unit test�

Unit testy jsou testy jednotliv�ch metod. V tomto p��pad� budeme testovat metody z rozhran� `IVypocty`.
1. P�ejmenujte soubor `UnitTest1.cs` na `VypoctyTests.cs`. Dotaz na p�ejmenov�n� t��dy odsouhlaste.
1. Klikn�te prav�m tla��tkem na Dependencies v projektu `CislaTests` a zvolte `Add Project Reference`. Za�krtn�te checkbox u projektu Cisla a potvr�te OK.
To umo�n� p��stup k typ�m a metod�m z projektu `Cisla` v testu.
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
        
    [Fact] je atribut, kter� ozna�uje metodu jako test. V�sledek testu je zelen�, pokud test pro�el, �erven� pokud selhal.
    N�zev testu je v�znamn�, proto�e se z n�j d� vysledovat, co test testuje. V tomto p��pad� testuje metodu NSD, kter� m� platn� vstup a v�sledek.

    Sekce Arrange testu slou�� k p��prav� testovac�ch dat. Vytvo��m si instanci t��dy Pocitadlo a p�iprav�m si prom�nn� a a b tak, �e v�m, jak� je jejich NSD. V�sledek o�ek�v�m 6.

    Sekce Act testu slou�� k vol�n� testovan� metody. V�sledek metody NSD ulo��m do prom�nn� vysledek.

    Sekce Assert testu slou�� k porovn�n� v�sledku s o�ek�van�m v�sledkem. V tomto p��pad� pou��v�m metodu Assert.Equal, kter� porovn� hodnoty dvou prom�nn�ch. Pokud se hodnoty rovnaj�, test pro�el, jinak selhal.

1. V menu Test si najd�te Test Explorer a nechte ho zobrazit. 
1. V Test Exploreru klikn�te na tla��tko Run All. Prob�hne build projektu a spust� se testy. V�sledek bude samoz�ejm� ne�sp�n�, proto�e nem�me je�t� naprogramovanou metodu NSD.
1. Ne� se vr�t�me k implementaci metody NSD, je�t� si vytvo��me testy pro dal�� metody. Vytvo�te si testy pro metody NSN, Faktorial a JePrvocislo. V�sledek by m�l vypadat takto:

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
	
	Jak je vid�t, testy jsou velmi podobn�. V�echny testy maj� stejnou strukturu, jen se li�� vstupn�mi a o�ek�van�mi v�stupy.

1. Vy�e�me je�t� ot�zku spu�t�n� test� s v�ce testovac�mi daty. To xUnit podporuje pomoc� attributu `Theory` a `InlineData`. Upravte test NSD takto:

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

1. Ve stejn�m duchu upravte i dal�� testy.

### Implementace metody NSD

1. Najd�te si algoritmus z v�po�tu NSD v minul�m cvi�en�. 
pou�ijte ji v metod� NSD v t��d� Pocitadlo. V�sledek by m�l vypadat takto:

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

1. Spus�te test metody NSD a ov��te, �e te� u� testy �sp�n� pro�ly.

### Implementace metody NSN

1. V�po�et NSN je d�n vzorcem, tak�e jej m��eme implementovat jednodu�e. V�sledek by m�l vypadat takto:

		public int NSN(int a, int b)
		{
			return (a * b) / NSD(a, b);
		}

1. Otestujte v�sledek podobn� jak u NSD.

### Implementace metody Faktorial

1. V�po�et faktori�lu je d�n rekurzivn�m vzorcem F(n) = n * F(n-1) a v�me �e F(1) = 1, tak�e jej m��eme implementovat jednodu�e. V�sledek by m�l vypadat takto:

		public int Faktorial(int a)
        {
            if (a == 1)
                return 1;
            else
                return a * Faktorial(a - 1);
        }

1. Op�t otestujte �e metoda vrac� o�ek�van� v�sledky.

### Implementace metody JePrvocislo

1. Prvo��slo je ��slo, kter� je d�liteln� pouze jedni�kou a sebou sam�m. Jedni�ka se za prvo��slo nepova�uje.
Z matematiky v�me, �e pokou�et se o d�len� sta�� jen do odmocniny z dan�ho ��sla. To v�znamn� zjednodu�� v�po�et.
D�le m��eme algoritmu uleh�it pr�ci, pokud hned na za��tku vy�e��me sud� ��sla. Jedin� sud� ��slo kter� je z�rove� prvo��slem je 2.
1. Prvn� ��st metody tak m��e vypadat takto:

		bool JePrvocislo(int a)
		{
			if (a == 2)
				return true;
			//Test zda je ��slo sud� (pomoc� nult�ho bitu, ten je u sud�ch ��sel v�dy 0)
			if ((a & 1) == 0)
				return false;
		}

1. Pro v�po�et odmocniny z ��sla m��eme pou��t metodu `Math.Sqrt`. K testov�n� d�len� se nejv�c hod� cyklus for.
Jako vylep�en� sta�� d�lit jen lich�mi ��sly, proto�e sud� ��sla jsme vy�e�ili v��e. 
Je�t� uprav�me n�zev parametru a, na vhodn�j�� `cislo`. Tak�e cel� metoda bude vypadat takto:

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

1. Te� m��ete spustit v�echny testy a ov��it, �e v�echny testy pro�ly.

### Optimalizace k�du

1. V�po�et NSD je sice funk�n�, ale extr�mn� neefektivn�, zejm�na pro velk� ��sla. Existuje mnohem lep�� algoritmus, kter� je zalo�en na z�sad�, �e NSD(a,b) = NSD(b,a % b). A v�po�et se prov�d� tak dlouho, dokud modulo nen� nula. Pak je b v�sledn�m NSD. Tak�e cel� metoda NSD m��e vypadat takto:

		public int NSD(int a, int b)
		{
			int c; // pomocn� prom�nn� pro prohozen� a a b
			while (b != 0)
			{
				c = a % b;
				a = b;
				b = c;
			}
			return a;
		}

1. Otestujte �e v�echny NSD testy st�le pro�ly.

Tento postup m� ofici�ln� n�zev **RGR => Red, Green, Refactor**. 
V prvn�m kroku se vytvo�� testy, kter� testuj� funk�nost k�du. 
V druh�m kroku se implementuje k�d, kter� testy proch�z�. 
V posledn�m kroku se k�d optimalizuje a zjednodu�uje na z�klad� v�sledku test� nebo znalosti v�voj��e.

### Kontrola vstupn�ch parametr�

1. V�echny metody v t��d� `Pocitadlo` maj� jako parametr ��slo typu int. Ale metody funguj� v oboru tzv. p�irozen�ch ��sel. Tak�e nap�. u ��sla -5 neplat�, �e by se jednalo o prvo��slo, proto�e definice prvo��sla vy�aduje, aby to bylo kladn� cel� ��slo v�t�� ne� 1.
1. Pro metodu `JePrvocislo` je tedy pot�eba p�idat kontrolu, zda je ��slo v�t�� ne� 1. Tady se ale objev� nov� ot�zka k rozhodnut�. Jak� chceme chov�n� metody JePrvocislo pro ��sla men�� ne� 2?
	* Jedna mo�nost je vr�tit `false`, tedy �e 1, 0, -1, -2 atd. nejsou prvo��sla.
	* Druh� mo�nost je vyvolat v�jimku, kter� bude ozna�ovat, �e byla zad�na neplatn� hodnota.

	Pozn. lektora: Osobn� v t�chto situac�ch preferuji vyvol�n� v�jimky a je pak v�c� toho, kdo metodu zavolal, zda ji odignoruje.
	
1. Za��tek metody `JePrvocislo` by tak mohl vypadat takto:

		public bool JePrvocislo(int cislo)
        {
			if (cislo < 2)
				throw new ArgumentOutOfRangeException(nameof(cislo), "Zda je ��slo prvo��slo lze ur�it jen pro ��sla v�t�� ne� 1");

1. Pro otestov�n� chov�n�, kdy ��douc� v�sledek je v�jimka, je nutn� ud�lat novou test metodu.
jej� k�d bude v tuto chv�li pro V�s mal� woo-doo.
Ale v�echno co pot�ebujete v�d�t je, �e v�jimka je typu `ArgumentOutOfRangeException`.

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

	Assert.Throws je metoda, kter� o�ek�v�, �e bude vyvol�na v�jimka v metod�, kter� je p�ed�na do metody jako parametr. 
	Tomu divn�mu v�razu se �ipkou se ��k� lambda v�raz a definuje se s n�m tzv. deleg�t. O tom je�t� bude na kurzu kapitola.

1. Nyn� m��ete spustit v�echny testy a ov��it, �e v�echny testy pro�ly.
1. P�ipravte principi�ln� stejn� testy pro metody `Faktorial`, `NSD` a `NSN`.
1. Ve stejn�m duchu m��ete p�idat kontrolu, zda jsou vstupn� parametry v�t�� ne� 0 i do metod `Faktorial`, `NSD` a `NSN`.

### Vstup ��sel z kl�vesnice nebo streamu

1. Metody VratCislo maj� umo�nit bu� vstup u�ivatelem zadan�ho ��sla, nebo vstup ze streamu.
1. Metoda VstupCisla kter� m� parametr string, jsme naprogramovali v cvi�en� 4.2 a sta�� jen zkop�rovat a jemn� upravit u� hotov� k�d.

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
                    Console.WriteLine("zadan� ��slo obsahuje neplatn� znaky, zkuste to znovu.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("zadan� ��slo je p��li� velk�, zkuste to znovu.");
                }
            }
            return cislo;
        }

1. Metoda VstupCisla kter� m� parametr stream bude pouze p�ev�d�t obsah ��dku na ��slo a budeme doufat �e to bude fungovat.

        public int VstupCisla(StreamReader reader)
        {
            return int.Parse(reader.ReadLine());
        }

1. Testy k t�mto metod�m te� d�lat nebudeme, tady je situace drobet slo�it�j��.

### Pou�it� knihovny Cisla v consolov� aplikaci Matika2

1. V projektu Matika2 klikn�te prav�m tla��tkem na `Dependencies` a vyberte volbu `Add Project Reference`.
1. V dialogu za�krtn�te checkbox u projektu `Cisla`.
1. V Program.cs vytvo�te k�d, kter�m z�sk�te od u�ivatele dv� ��sla. K t�m mu spo��t�te a vyp�ete NSD a NSN.
1. D�le si vy��d�te od u�ivatele ��slo a vyp�ete, zda je prvo��slo.
1. Nakonec si vy��d�te od u�ivatele ��slo a vyp�ete jeho faktori�l.
1. K�d by mohl vypadat takto

		using Cisla;

		IVypocty vypocty = new Pocitadlo();

		int a = vypocty.VstupCisla("Zadejte prvn� ��slo");
		int b = vypocty.VstupCisla("Zadejte druh� ��slo");

		Console.WriteLine($"NSD({a},{b})={vypocty.NSD(a,b)}");
		Console.WriteLine($"NSN({a},{b})={vypocty.NSN(a,b)}");

		int c = vypocty.VstupCisla("Zadejte ��slo pro zji�t�n�, zda je prvo��slo");
		Console.WriteLine($"Je ��slo {c} prvo��slo? {vypocty.JePrvocislo(c)}");

		int d = vypocty.VstupCisla("Zadejte ��slo pro v�po�et faktori�lu");
		Console.WriteLine($"Faktori�l ��sla {d} je {vypocty.Faktorial(d)}");

1. Nezapome�te nastavit Matika2 ja StartUp projekt a spus�te aplikaci a ov��te, �e v�e funguje.

Jak vid�te, p�i programov�n� se preferuje pou��v�n� interface, kter� je vytvo�en pro danou �lohu.
D�le samotn� v�konn� k�d je zvykem d�vat do knihoven, aby byl znovupou�iteln� v jin�ch projektech.
Pak lze jednodu�e aplikovat testy, pro garanci �e v knihovn� je k�d spr�vn�.
A pou�it� dob�e navr�en� knihovny je pak p��mo�ar� a jednoduch�.

A ot�zka na z�v�r:

**Jak� m�te pocit z metod VstupCisla v interface Vypocty?**