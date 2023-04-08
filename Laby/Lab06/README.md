# Lab 6

## Pou�it� pol� a kolekc�

### P��prava

1. Vytvo�te slo�ku pro Lab6 a zkop�rujte tam cel� obsah slo�ky Lab5.
1. Otev�te solution ze slo�ky Lab6 ve Visual Studiu a spus�te aplikaci.
1. Pokud v�e funguje, m��ete pokra�ovat.

### Vytvo�en� IVstupCisel t��dy CislaVstup

1. Do projektu Cisla p�idejte interface IVstupCisel.
1. P�esu�te do n�j deklaraci metod VstupCisla z interface IVypocty

		namespace Cisla;

        public interface IVstupCisel
        {
            int VstupCisla(string dotaz);
            int VstupCisla(StreamReader reader);
        }

1. Vytvo�te t��du CislaVstup, kter� implementuje interface IVstupCisel.
1. Kod metod zkop�rujte z t��dy Pocitadlo.

        namespace Cisla;

        public class CislaVstup : IVstupCisel
        {
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

            public int VstupCisla(StreamReader reader)
            {
                return int.Parse(reader.ReadLine());
            }
        }

1. V projektu Matika2 p�idejte na za��tek ��dek pro vytvo�en� instance t��dy CislaVstup a pou�ijte ji pro vstup hodnot

        IVstupCisel vstup = new CislaVstup();
        ...
        int a = vstup.VstupCisla("Zadejte prvn� ��slo: ");

### Vytvo�en� testu pro Eratostenovo sito

1. V projektu CislaTests do t��dy VypoctyTests p�idejte novou metodu `VratPrvocisla_ValidnyVstup_Vysledok`.
1. V metod� p�ipravte pole obsahuj�c� prvo��sla do 100.
1. Pak zavolejte metodu s limitem 100
1. pomoc� Assert.Equal porovnejte ob� pole (metoda porovn�v� prvek po prvku a skon�� �sp�n� jen kdy� je obsah pol� stejn�.

        [Fact]
        public void VratPrvocisla_ValidnyVstup_Vysledok()
        {
            //Arange
            IVypocty vypocty = new Pocitadlo();
            int max = 100;
            int[] ocekavam = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            //Act
            int[] vysledek = vypocty.VratPrvocisla(max);

            //Assert
            Assert.Equal(ocekavam, vysledek);
        }

### Metoda pro implementaci Eratostenova s�ta

1. Do interface IVypocty p�idejte metodu `int[] VratPrvocisla(int maxCislo)`.
1. Do t��dy Pocitadlo p�idejte implementaci metody `VratPrvocisla`.
1. Metoda bude vracet pole prvo��sel men��ch ne� maxCislo.
1. Prvn� krok je vytvo�en� dostate�n� velk�ho pole boolean�. V�choz� hodnota booleanu je false, tak�e cel� pole je inicializovan� na false.
1. Index pole boolean� reprezentuje identick� ��slo. Nap��klad index 2 reprezentuje ��slo 2.
1. Zvol�m�, �e �krtnut� pole bude reprezentov�no nastaven�m booleanu na **true**. Hned na za��tku nastav�me true do indexu 0 a 1, proto�e to nejsou prvo��sla.
1. Pot� projdeme pole boolean� a pro v�echny indexy, kter� jsou false, nastav�me na true v�echny jejich n�sobky.
1. Pole budeme proch�zet do odmocniny z maxCisla, proto�e v�echny n�sobky ��sla v�t��ho ne� odmocnina z maxCisla jsou ji� obsa�eny v n�sobc�ch men��ch ��sel.
1. V�sledkem je pole boolean�, kde jsou false pouze na indexech, kter� odpov�daj� prvo��sl�m.
1. Nejd��v spo��t�me, kolik prvk� pole z�stalo s hadnotou false, co� je po�et prvo��sel.
1. Pot� vytvo��me pole o velikosti po�tu prvo��sel.
1. Nakonec projdeme pole boolean� a do pole prvo��sel p�id�me ��sla odpov�daj�c� index�m s hodnotou false.

		public int[] VratPrvocisla(int maxCislo)
        {
            if (maxCislo < 2)
                throw new ArgumentOutOfRangeException("maxCislo", "parametr mus� b�t v�t�� ne� 1");
            //Eratostenovo sito
            // false - ne�krtnuto, true - �krtnuto
            bool[] pole = new bool[maxCislo + 1];
            pole[0] = true;
            pole[1] = true;

            int limit = (int)Math.Sqrt(maxCislo) + 1;

            //A� po limit hled�m zat�m ne�krtnut� ��sla
            for (int cislo = 2; cislo < limit; cislo++)
            {
                //Pokud je ��slo u� �krtunt�, jdu na dal��
                if (pole[cislo])
                    continue;

                //Vy�krt�m v�echny n�sobky ne�krtnut�ho ��sla, tedy �krt�m od x+x a� po konec
                for (int i = cislo * 2; i < pole.Length; i += cislo)
                {
                    pole[i] = true;
                }
            }
            //Priprava vysledneho pola prvocisel. Mus�m zjistit kolik t�ch prvo��sel z�stalo
            int pocet = 0;
            foreach (bool item in pole)
            {
                if (!item)
                    pocet++;
            }

            int[] vysledek = new int[pocet];

            //Do vysledek pot�ebuji zapsat ��sla odpov�daj�c� pol��ku s hodnotou false
            int index = 0; // slou�� jako index do v�sledn�ho pole, abych v�d�l kam zapsat dal�� prvo��slo
            for (int cislo = 0; cislo < pole.Length; cislo++)
            {
                if (!pole[cislo])
                {
                    vysledek[index] = cislo;
                    index++;
                }
            }

            return vysledek;
        }

1. Otestujte UnitTestem �e metoda funguje.

### V�pis ��sel

1. Do projektu Cisla p�idejte interface `IVystupCisel`.
1. V interfece zadefinujte p�edpis metody pro v�pis ��sel. Metoda bude m�t t�i parametry. 
    * Pole ��sel, kter� se maj� vypsat.
    * Po�et ��sel vypsan�ch na jeden ��dek
    * TextWriter kter�m se maj� ��sla vypsat

V�sledek bude vypadat takto:

        namespace Cisla;

        public interface IVystupCisel
        {
            void VypisCisel(int[] data, int pocetNaRadek, TextWriter vystup);
        }

1. Do projektu Cisla p�idejte t��du `CislaVystup`.
1. T��da implementuje interface `IVystupCisel`.
1. Existuje n�kolik cest jak zajistit v�pis ��sel. Probl�m je spr�vn� vy�e�it ot�zku, kdy p�idat do v�stupu odd�lova� s mezerou.
	* M��eme p�idat odd�lova� p�ed ka�d�m ��slem, krom� prvn�ho.
	* M��eme p�idat odd�lova� za ka�d�m ��slem, krom� posledn�ho.
	* M��eme vyu��t metodu `String.Join` kter� spoj� �et�zce a vlo�� mezi n� odd�lovac� znak

    Uk�zkov� k�d jde cestou p�id�n� odd�lova�e p�ed ��slo, krom� prvn�ho na ��dku

        namespace Cisla;

        public class CislaVystup : IVystupCisel
        {
            public void VypisCisel(int[] data, int pocetNaRadek, TextWriter vystup)
            {
                bool start = true; //indikuje zda jsem na za��tku ��dku

                int pocet = 0; //napo��t�v�m po�et vypsan�ch ��sel

                foreach (int cislo in data)
                {
                    // pokud nejsem na za��tku ��dku, nap�u p�ed ��slo ��rku a mezeru
                    if (start)
                    {
                        start = false;
                    }
                    else
                    {
                        vystup.Write(", ");
                    }

                    vystup.Write(cislo);
                    pocet++;

                    // pokud dos�hnu po�tu ��sel na ��dek, od��dkuji a obnov�m ��d�c� prom�nn�
                    if (pocet == pocetNaRadek)
                    {
                        start = true;
                        pocet = 0;
                        vystup.WriteLine();
                    }
                }
            }
        }

1. P�idejte v projektu Matika2 do t��dy `Program` vytvo�en� instance t��dy `CislaVypis`.
1. Pak si vy��dejte od u�ivatele zad�n� maxim�ln�ho ��sla pro hled�n� prvo��sel
1. Zavolejte metodu `VratPrvocisla` a v�sledek ulo�te do pole.
1. Zavolejte metodu `VypisCisel` a v�sledek vypi�te na konzoli (vlastnost `Console.Out`).
1. V�sledek by mohl vypadat takto:

        IVystupCisel vystup = new CislaVystup();
        ...
        int e = vstup.VstupCisla("Zadejte maxim�ln� ��slo pro v�pis prvo��sel");
        Console.WriteLine($"Prvo��sla do {e} jsou:");
        int[] data = vypocty.VratPrvocisla(e);
        vystup.VypisCisel(data, 10, Console.Out);

1. Spus�te aplikaci Matematika2 a otestujte pro v�t�� prvo��sla (nap�. max 10 000), �e v�po�et i v�pis funguje.
