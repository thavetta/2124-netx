using System.Diagnostics;
using System.Text;

namespace Retezce;

public class Utils
{
    /// <summary>
    /// Metoda do Debug okna vypíše informace o typu proměnné pomocí reflexe.
    /// </summary>
    /// <param name="prom">proměnná jakéhokoliv typu</param>
    public static void VypisTyp(object prom)
    {
        Type type = prom.GetType();
        Debug.WriteLine("Jmeno typu:" + type.FullName);
        string urceniTypu = type.IsValueType ? "je hodnotovy" : "je referencni";
        Debug.WriteLine("Typ " + urceniTypu);
        Debug.WriteLine("Assembly:" + type.AssemblyQualifiedName);
    }

    /// <summary>
    /// Metoda vrátí reverzní řetězec, tedy například pro vstup "pokus" vrátí "sukop".
    /// </summary>
    /// <param name="vstup">vstupní řetězec, z kterého se vytvoří reverzní</param>
    /// <returns>reverzní řetězec</returns>
    /// <remarks>V .NETu samozřejmě pro tuto funkcionalitu existuje hotové řešení.</remarks>
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

    /// <summary>
    /// Metoda vrací pole znaků, které mají ve vstupním řetězci největší počet výskytů 
    /// </summary>
    /// <param name="vstup">řetězec, který se má zpracovat</param>
    /// <returns>pole, které obsahuje znaky s největším počtem výskytů ve vstupním řetězci</returns>
    public static char[] NejvicVyskytu(string vstup)
    {
        if (string.IsNullOrEmpty(vstup))
            return new char[0];

        Dictionary<char, int> seznam = new ();

        //Cyklus prochází znaky a napočítává výskyt
        foreach (char znak in vstup)
        {
            if (seznam.ContainsKey(znak))
                seznam[znak]++;
            else
                seznam.Add(znak, 1);
        }

        //Najde největší výskyt
        int max = int.MinValue;

        foreach (var value in seznam.Values) 
            max = Math.Max(max, value);

        //Najde počet znaků s největším výskytem
        int pocetMax = 0;
        
        foreach (int item in seznam.Values)
        {
            if (item == max)
                pocetMax++;
        }

        //Vytvoří výstupní pole podle zjištěného počtu
        char[] vysledek = new char[pocetMax];

        //Naplní pole znaky s největším výskytem
        int index = 0;

        foreach (KeyValuePair<char, int> item in seznam)
        {
            if (item.Value != max) 
                continue;
            vysledek[index] = item.Key;
            index++;
        }

        return vysledek;
    }

    /// <summary>
    /// Ukázka řešení spočítání výskytu znaků pomocí LINQ
    /// </summary>
    /// <param name="vstup">řetězec, který se má zpracovat</param>
    /// <returns>pole, které obsahuje znaky s největším počtem výskytů ve vstupním řetězci</returns>
    public static char[] NejvicVyskytuLinq(string vstup)
    {
        if (string.IsNullOrEmpty(vstup))
            return new char[0];

        var data = (from x in vstup
            group x by x)
            .ToDictionary(x => x.Key, x => x.Count());

        int max = data.Values.Max();

        char[] vysledek = data
            .Where(x => x.Value == max)
            .Select(x => x.Key)
            .ToArray();

        return vysledek;
    }
}
