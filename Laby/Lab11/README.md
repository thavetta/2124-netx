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
