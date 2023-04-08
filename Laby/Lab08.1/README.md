# Lab 8.1

## Základy práce s referenèními typy

Cílem tohoto cvièení je seznámit se s referenèními typy v jazyce C# a s jejich vyuitím.
Vyuijeme pøipravené Unit Testy, tentokrát v MS frameworku, kterı pouívá jiné attributy ne xUnit.
Princip Unit Testù je stejnı jako v pøedchozích cvièeních.

### Pøíprava

1. Ve sloce s laby najdìte v Lab8.1 sloku Start. Z ní si vykopírujte do pracovního prostoru pøipravenou Solution `RetazceSol`.
1. Solution obsahuje dva projekty
	
	* `Retezce` - knihovna s implementací metod pro práci s øetìzci
	* `Retezcetests` - unit testy pomocí frameworku MS test v. 2

1. Projekt `Retezce` obsahuje tøídu `Utils` s pøipravenımi metodami, které chceme vytvoøit.
1. Projekt `RetezceTests` obsahuje tøídu `UtilsTests` s pøipravenımi testy, které chceme aby skonèili úspìchem.
1. Zkuste spustit všechny testy. Kompilace by mìla probìhnout OK, ale testy selou.

### Implementace metody VratOtoceny

1. Kód této metody umoòuje rùzné cesty øešení. Nejdøív si zkuste vymyslet vlastní algoritmus jak by se dalo postupovat.
1. Moné øešení vychází z toho, e vyuijeme tøídu StringBuilder a vyskládáme øetìzec pøidáváním znakù, které získáme pøi procházení pole znakù od konce.
1. Ne zaènete øetìzec zpracovávat, otestujte zda není null, pøípadnì zda není prázdnı.
1. Vytvoøte si instanci tøídy `StringBuilder` a pøedáte mu délku vstupního øetìzce. Reverzní øetìzec bude stejnì dlouhı a StringBuilderu tak ulehèíme práci.
1. Vyuijte metodu `Append` tøídy `StringBuilder` pro pøidání znaku na konec øetìzce.
1. Vyuijte metodu `ToString` tøídy `StringBuilder` pro pøevod na øetìzec.
1. Kód by mohl vypadat takto:

		public static string VratOtoceny(string vstup)
        {
            if (vstup == null)
                return null;
            if (string.IsNullOrEmpty(vstup))
                return String.Empty;

            StringBuilder sb = new StringBuilder(vstup.Length);

            for (int i = vstup.Length - 1; i >= 0; i--)
            {
                sb.Append(vstup[i]);
            }

            return sb.ToString();
        }

1. Spuste testy a zkontrolujte, e všechny testy pro tuto metodu prošly.

### Implementace metody NejvicVyskytu

1. Opìt nejdøíve zkuste vymyslet vlastní øešení a implementovat ho.
1. Moné øešení vychází z toho, e vyuijeme tøídu Dictionary, která umoòuje ukládat hodnoty podle klíèe. To nám umoní jednoduše pøiøadit písmenùm poèet vıskytù.
1. Ne zaènete øetìzec zpracovávat, otestujte zda není null, pøípadnì zda není prázdnı.
1. Vytvoøte si instanci tøídy `Dictionary<char, int>`. Typ char bude tzv. klíè, int pak urèuje ke klíèi navázanou hodnotu.
1. Vyuijte cyklus `foreach` pro procházení všech znakù vstupního øetìzce.
1. Vyuijte metodu `ContainsKey` tøídy `Dictionary` pro zjištìní, zda ji v Dictionary je záznam pro danı klíè.
1. Pokud ji záznam existuje, zvıšte hodnotu o 1.
1. Pokud záznam neexistuje, vlote do Dictionary záznam s klíèem znaku a hodnotou 1.
1. Tato èást by mohla vypadat takto

        public static char[] NejvicVyskytu(string vstup)
        {
            if (string.IsNullOrEmpty(vstup))
                return new char[0];

            Dictionary<char, int> seznam = new ();

            //Cyklus prochází znaky a napoèítává vıskyt
            foreach (char znak in vstup)
            {
                if (seznam.ContainsKey(znak))
                    seznam[znak]++;
                else
                    seznam.Add(znak, 1);
            }
        ...

1. Kadá Dictionary má vlastnost Keys - ta zpøístupní kolekci klíèù a Values - která zpøístupní kolekci hodnot.
1. Teï zjistíme nejvyšší poèet vıskytù. Vyuijeme metodu `Max` tøídy `Math`.
1. Kód by mohl vypadat takto:

        //Najde nejvìtší vıskyt
        int max = int.MinValue;

        foreach (var value in seznam.Values) 
            max = Math.Max(max, value);

1. Jakmile máme maximum, potøebujeme zjistit kolik je takovıchto znakù. 
1. Proiterujeme opìt kolekci Values a hledáme jen ty co mají maximální hodnotu.

        //Najde poèet znakù s nejvìtším vıskytem
        int pocetMax = 0;
        
        foreach (int item in seznam.Values)
        {
            if (item == max)
                pocetMax++;
        }

1. Vytvoøíme si pole o velikosti poètu znakù s nejvìtším vıskytem.
1. Projdeme opìt kolekci Values a hledáme znaky s maximálním vıskytem. Ty pak pøidáme do pole.

        //Vytvoøí vıstupní pole podle zjištìného poètu
        char[] vysledek = new char[pocetMax];

        //Naplní pole znaky s nejvìtším vıskytem
        int index = 0;

        foreach (KeyValuePair<char, int> item in seznam)
        {
            if (item.Value != max) 
                continue;
            vysledek[index] = item.Key;
            index++;
        }

1. Vısledné pole vracíme.

        return vysledek;

1. Ovìøte buildem e nemáte nikde chybu která by bránila kompilaci.
1. Spuse pøipravené testy. Mìly by skonèit úspìchem.
		