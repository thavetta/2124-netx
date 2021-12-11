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
}
