namespace Cisla;

public class Pocitadlo
{
    public static int NactiCislo(string text = "Zadej číslo:")
    {
        int cislo;
        while (true)
        {
            Console.WriteLine(text);
            if (int.TryParse(Console.ReadLine(), out cislo))
                break;
            Console.WriteLine("Nekorektně zadané číslo / opakujte");

        }
        return cislo;
    }

    public static int NSD(int x, int y)
    {
        if (x < 1 || y < 1)
            throw new ArgumentOutOfRangeException("Vstup musí být kladný větší než 0");

        while (x != y)
        {
            if (x > y)
            {
                x -= y;
            }
            else
            {
                y -= x;
            }
        }
        return x;
    }

    public static int NSN(int x, int y)
    {
        return x * y / NSD(x, y);
    }

    public static int Faktorial(int x)
    {
        if (x == 1)
            return 1;

        return x * Faktorial(x - 1);
    }

    public static bool JePrvocislo(int x)
    {
        // Pro čísla menší než 2 nejde vůbec mluvit o prvočíslech
        if (x < 2)
            return false;

        //Dvojka je jediné sudé prvočíslo
        if (x == 2)
            return true;

        //Pokud je bit 0 rovný nule, je číslo sudé a tedy není prvočíslo (dvojku vyřadil předešlý test) 
        if ((x & 1) == 0)
            return false;

        //Dělite má smysl hledat jen do odmocniny z testovaného čísla
        int limit = (int)Math.Sqrt(x) + 1;

        //Nemá smysl dělit sudým číslem, sudé číslo krát cokoliv je sudé číslo a my máme teď jasno, že naše číslo je liché.
        for (int delic = 3; delic < limit; delic += 2)
        {
            //Pokud najdu dělitele, je číslo prvočíslo
            if ((x % delic) == 0)
                return false;
        }

        //Pokud jsem nenašel dělitele, je číslo prvočíslo
        return true;

    }

  
    public static int[] VratPrvocisla(int maxCislo)
    {
        if (maxCislo < 2)
            throw new ArgumentOutOfRangeException("maxCislo", "parametr musí být větší než 1");
        //Eratostenovo sito
        // false - neškrtnuto, true - škrtnuto
        bool[] pole = new bool[maxCislo + 1];
        pole[0] = true;
        pole[1] = true;

        int limit = (int)Math.Sqrt(maxCislo) + 1;

        //Až po limit hledám zatím neškrtnutá čísla
        for (int cislo = 2; cislo < limit; cislo++)
        {
            //Pokud je číslo už škrtunté, jdu na další
            if (pole[cislo])
                continue;

            //Vyškrtám všechny násobky neškrtnutého čísla, tedy škrtám od x+x až po konec
            for (int i = cislo * 2; i < pole.Length; i += cislo)
            {
                pole[i] = true;
            }
        }
        //Priprava vysledneho pola prvocisel. Musím zjistit kolik těch prvočísel zůstalo
        int pocet = 0;
        foreach (bool item in pole)
        {
            if (!item)
                pocet++;
        }

        int[] vysledek = new int[pocet];

        //Do vysledek potřebuji zapsat čísla odpovídající políčku s hodnotou false
        int index = 0; // slouží jako index do výsledného pole, abych věděl kam zapsat další prvočíslo
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

    public static void VypisCisla(int[] data, int pocetNaRadek = 10)
    {
        bool start = true; //indikuje zda jsem na začátku řádku

        int pocet = 0; //napočítávám počet vypsaných čísel

        foreach (int cislo in data)
        {
            // pokud nejsem na začátku řádku, napíšu před číslo čárku a mezeru
            if (start)
            {
                start = false;
            }
            else
            {
                Console.Write(", ");
            }

            Console.Write(cislo);
            pocet++;

            // pokud dosáhnu počtu čísel na řádek, odřádkuji a obnovím řídící proměnné
            if (pocet == pocetNaRadek)
            {
                start = true;
                pocet = 0;
                Console.WriteLine();
            }

        }
    }

}
