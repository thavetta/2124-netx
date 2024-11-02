# Lab 11

## Základy dědičnosti

V tomto cvičení budeme definovat jednoduchou dědičnostní hierarchii zvířat v ZOO a cílem bude jednoduše získat seznam jídla pro ranní a večerní krmení zvířat.
Metody pro zjištění jídla určí interface IJidlo. Pro zvířata vytvoříme společnou abstraktní třídu Zvire.
Cílem je ukázat jednoduchost přidání dalších zvířat v budoucnu.

### Vytvoření knihovny zvířat

1. Vytvořte nový projekt typu Class Library pro jazyk C# a pojmenujte jej `ZooLib`.
1. Připravený `Class1` přejmenujte na `Zvire`.
1. Přidejte do projektu soubor pro interface `IJidlo`. V něm zadefinujte metody vracející string s názvem `RanniDavka` a `VecerniDavka`. Kód by mohl vypadat takto:

    ```csharp
    public interface IJidlo
    {
        string RanniDavka();
        string VecerniDavka();
    }
    ```

1. Vraťte se k souboru `Zvire.cs` a upravte obsah definice třídy `Zvire`. Třída je abstraktní. Třída implementuje IJidlo pomocí abstraktních metod. Třída definuje automatické property Vek (typ int) a Jmeno (string).
1. Třída `Zvire` by měla být definována takto:

    ```csharp

    public abstract class Zvire : IJidlo
    {
        public abstract string RanniDavka();
        public abstract string VecerniDavka();

        public string Jmeno { get; set; }
        public int Vek { get; set; }
    }
    ```

1. Přidejte do projektu alespoň čtyři třídy reprezentující zvířata a zadefinujte jim co by se jim asi líbilo k jídlu.
1. Například Slon by mohl být zadefinován takto:

    ```csharp
    public class Slon : Zvire
    {
        public override string RanniDavka()
        {
            return "10 kg jablek";
        }

        public override string VecerniDavka()
        {
            return "20 kg sena";
        }
    }
    ```

1. Jakmile budete mít alespoň 4 konkrétní zvířata, můžete přidat poslední třídu, která bude mít za úkol zajistit výpis ranních a večerních požadavků zvířat. Dostane název `ObjednavacJidla`.
1. Metody pro výpis nazvěte `PripravRanniObjednavku` a `PripravVecerniObjednavku`.
1. Pro plné uplatnění abstrakce metody dostanou sice kolekci zvířat, ale požadavek na parametr bude co nejvíc abstraktní. Proto využijeme generický interface `IEnumerable<T>`, kterému jako požadavek na typ `T`určíme, že to má být jakýkoliv typ implementující IJidlo. Tím první parametr může být jakákoliv kolekce obsahující typy implementující `IJidlo`.
1. Druhý parametr metody umožní zapsat výstup do jakéhokoliv StreamWriteru. Jako defaultní hodnotu určete Console.Out. Pokud bude uživatel chtít, může naprogramovat výstup do souboru.
1. Uvnitř metody nejdřív vypište o jaký typ dávky se jedná a pak pomocí foreach projděte kolekci předanou jako parametr a pro každé zvíře vyvolejte patřičnou metodu pro výpis jídla.
1. Výsledek může vypadat například takto:

    ```csharp
    public class ObjednavacJidla
    {
        public void PripravRanniObjednavku(IEnumerable<IJidlo> seznam, StreamWriter vystup = Console.Out)
        {
            vystup.WriteLine("Objednávka na ráno:");
            foreach (IJidlo item in seznam)
            {
                vystup.WriteLine(item.RanniDavka());
            }
            vystup.WriteLine("*********************");
        }

        public void PripravVecerniObjednavku(IEnumerable<IJidlo> seznam, StreamWriter vystup = Console.Out)
        {
            vystup.WriteLine("Objednávka na večer:");
            foreach (IJidlo item in seznam)
            {
                vystup.WriteLine(item.VecerniDavka());
            }
            vystup.WriteLine("*********************");
        }
    }
    ```

### Aplikace pracující se zvířaty

1. Do solution přidejte nový projekt typu konzolová aplikace a nazvěte ho `Zoo`
1. Přidejte referenci na knihovnu `ZooLib`
1. V `Program.cs` přidejte kód, který vytvoří kolekci zvířat, pak instanci třídy `ObjednavacJidla` a zavolá metody pro výpis ranních požadavků na jídlo a pak večerních.
1. Kód by mohl vypadat takto (typy zvířat použijte podle toho, co za zvířata jste si zadefinovali):

    ```csharp
    using ZooLib;

    List<Zvire> seznam = new()
            {
                new Slon() { Jmeno = "Franta", Vek = 10},
                new Klokan() { Jmeno = "Baltazar", Vek = 5},
                new Papagaj() { Jmeno = "Kral", Vek = 45},
                new Papagaj() { Jmeno = "Kralovna", Vek = 35},
                new Kun() { Jmeno = "Frantiska", Vek = 4}
            };

    ObjednavacJidla objednavac = new();

    objednavac.PripravRanniObjednavku(seznam);

    objednavac.PripravVecerniObjednavku(seznam);

    ```

1. Otestujte aplikaci, zda vypisuje jídla dle očekávání.
1. Přidejte do `ZooLib` další třídu pro nové zvíře.
1. V Program.cs přidejte do vytvářené kolekce nové zvíře.
1. Ověřte že aplikace bude vypisovat i požadavky na jídlo nového typu zvířat. Uvědomte si, že v aplikaci jste museli změnit pouze kód plnící kolekci zvířat. Vše ostatní zůstalo beze změny.
