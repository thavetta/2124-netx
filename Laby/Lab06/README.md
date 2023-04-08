# Lab 6

## Pouití polí a kolekcí

### Pøíprava

1. Vytvoøte sloku pro Lab6 a zkopírujte tam celı obsah sloky Lab5.
1. Otevøte solution ze sloky Lab6 ve Visual Studiu a spuste aplikaci.
1. Pokud vše funguje, mùete pokraèovat.

### Vytvoøení IVstupCisel tøídy CislaVstup

1. Do projektu Cisla pøidejte interface IVstupCisel.
1. Pøesuòte do nìj deklaraci metod VstupCisla z interface IVypocty

		namespace Cisla;

        public interface IVstupCisel
        {
            int VstupCisla(string dotaz);
            int VstupCisla(StreamReader reader);
        }

1. Vytvoøte tøídu CislaVstup, která implementuje interface IVstupCisel.
1. Kod metod zkopírujte z tøídy Pocitadlo.

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
                        Console.WriteLine("zadané èíslo obsahuje neplatné znaky, zkuste to znovu.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("zadané èíslo je pøíliš velké, zkuste to znovu.");
                    }
                }
                return cislo;
            }

            public int VstupCisla(StreamReader reader)
            {
                return int.Parse(reader.ReadLine());
            }
        }

1. V projektu Matika2 pøidejte na zaèátek øádek pro vytvoøení instance tøídy CislaVstup a pouijte ji pro vstup hodnot

        IVstupCisel vstup = new CislaVstup();
        ...
        int a = vstup.VstupCisla("Zadejte první èíslo: ");

### Vytvoøení testu pro Eratostenovo sito

1. V projektu CislaTests do tøídy VypoctyTests pøidejte novou metodu `VratPrvocisla_ValidnyVstup_Vysledok`.
1. V metodì pøipravte pole obsahující prvoèísla do 100.
1. Pak zavolejte metodu s limitem 100
1. pomocí Assert.Equal porovnejte obì pole (metoda porovnává prvek po prvku a skonèí úspìšnì jen kdy je obsah polí stejnı.

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

### Metoda pro implementaci Eratostenova síta

1. Do interface IVypocty pøidejte metodu `int[] VratPrvocisla(int maxCislo)`.
1. Do tøídy Pocitadlo pøidejte implementaci metody `VratPrvocisla`.
1. Metoda bude vracet pole prvoèísel menších ne maxCislo.
1. První krok je vytvoøení dostateènì velkého pole booleanù. Vıchozí hodnota booleanu je false, take celé pole je inicializované na false.
1. Index pole booleanù reprezentuje identické èíslo. Napøíklad index 2 reprezentuje èíslo 2.
1. Zvolímì, e škrtnuté pole bude reprezentováno nastavením booleanu na **true**. Hned na zaèátku nastavíme true do indexu 0 a 1, protoe to nejsou prvoèísla.
1. Poté projdeme pole booleanù a pro všechny indexy, které jsou false, nastavíme na true všechny jejich násobky.
1. Pole budeme procházet do odmocniny z maxCisla, protoe všechny násobky èísla vìtšího ne odmocnina z maxCisla jsou ji obsaeny v násobcích menších èísel.
1. Vısledkem je pole booleanù, kde jsou false pouze na indexech, které odpovídají prvoèíslùm.
1. Nejdøív spoèítáme, kolik prvkù pole zùstalo s hadnotou false, co je poèet prvoèísel.
1. Poté vytvoøíme pole o velikosti poètu prvoèísel.
1. Nakonec projdeme pole booleanù a do pole prvoèísel pøidáme èísla odpovídající indexùm s hodnotou false.

		public int[] VratPrvocisla(int maxCislo)
        {
            if (maxCislo < 2)
                throw new ArgumentOutOfRangeException("maxCislo", "parametr musí bıt vìtší ne 1");
            //Eratostenovo sito
            // false - neškrtnuto, true - škrtnuto
            bool[] pole = new bool[maxCislo + 1];
            pole[0] = true;
            pole[1] = true;

            int limit = (int)Math.Sqrt(maxCislo) + 1;

            //A po limit hledám zatím neškrtnutá èísla
            for (int cislo = 2; cislo < limit; cislo++)
            {
                //Pokud je èíslo u škrtunté, jdu na další
                if (pole[cislo])
                    continue;

                //Vyškrtám všechny násobky neškrtnutého èísla, tedy škrtám od x+x a po konec
                for (int i = cislo * 2; i < pole.Length; i += cislo)
                {
                    pole[i] = true;
                }
            }
            //Priprava vysledneho pola prvocisel. Musím zjistit kolik tìch prvoèísel zùstalo
            int pocet = 0;
            foreach (bool item in pole)
            {
                if (!item)
                    pocet++;
            }

            int[] vysledek = new int[pocet];

            //Do vysledek potøebuji zapsat èísla odpovídající políèku s hodnotou false
            int index = 0; // slouí jako index do vısledného pole, abych vìdìl kam zapsat další prvoèíslo
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

1. Otestujte UnitTestem e metoda funguje.

### Vıpis èísel

1. Do projektu Cisla pøidejte interface `IVystupCisel`.
1. V interfece zadefinujte pøedpis metody pro vıpis èísel. Metoda bude mít tøi parametry. 
    * Pole èísel, které se mají vypsat.
    * Poèet èísel vypsanıch na jeden øádek
    * TextWriter kterım se mají èísla vypsat

Vısledek bude vypadat takto:

        namespace Cisla;

        public interface IVystupCisel
        {
            void VypisCisel(int[] data, int pocetNaRadek, TextWriter vystup);
        }

1. Do projektu Cisla pøidejte tøídu `CislaVystup`.
1. Tøída implementuje interface `IVystupCisel`.
1. Existuje nìkolik cest jak zajistit vıpis èísel. Problém je správnì vyøešit otázku, kdy pøidat do vıstupu oddìlovaè s mezerou.
	* Mùeme pøidat oddìlovaè pøed kadım èíslem, kromì prvního.
	* Mùeme pøidat oddìlovaè za kadım èíslem, kromì posledního.
	* Mùeme vyuít metodu `String.Join` která spojí øetìzce a vloí mezi nì oddìlovací znak

    Ukázkovı kód jde cestou pøidání oddìlovaèe pøed èíslo, kromì prvního na øádku

        namespace Cisla;

        public class CislaVystup : IVystupCisel
        {
            public void VypisCisel(int[] data, int pocetNaRadek, TextWriter vystup)
            {
                bool start = true; //indikuje zda jsem na zaèátku øádku

                int pocet = 0; //napoèítávám poèet vypsanıch èísel

                foreach (int cislo in data)
                {
                    // pokud nejsem na zaèátku øádku, napíšu pøed èíslo èárku a mezeru
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

                    // pokud dosáhnu poètu èísel na øádek, odøádkuji a obnovím øídící promìnné
                    if (pocet == pocetNaRadek)
                    {
                        start = true;
                        pocet = 0;
                        vystup.WriteLine();
                    }
                }
            }
        }

1. Pøidejte v projektu Matika2 do tøídy `Program` vytvoøení instance tøídy `CislaVypis`.
1. Pak si vyádejte od uivatele zadání maximálního èísla pro hledání prvoèísel
1. Zavolejte metodu `VratPrvocisla` a vısledek ulote do pole.
1. Zavolejte metodu `VypisCisel` a vısledek vypište na konzoli (vlastnost `Console.Out`).
1. Vısledek by mohl vypadat takto:

        IVystupCisel vystup = new CislaVystup();
        ...
        int e = vstup.VstupCisla("Zadejte maximální èíslo pro vıpis prvoèísel");
        Console.WriteLine($"Prvoèísla do {e} jsou:");
        int[] data = vypocty.VratPrvocisla(e);
        vystup.VypisCisel(data, 10, Console.Out);

1. Spuste aplikaci Matematika2 a otestujte pro vìtší prvoèísla (napø. max 10 000), e vıpoèet i vıpis funguje.
