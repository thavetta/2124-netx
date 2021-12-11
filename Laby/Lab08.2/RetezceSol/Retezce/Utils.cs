using System.Diagnostics;
using System.Text;

namespace Retezce;

public class Utils
{
    public static void VypisTyp(object prom)
    {
        Type type = prom.GetType();
        Debug.WriteLine("Jmeno typu:" + type.FullName);
        string hodnotovy = type.IsValueType ? "je hodnotovy" : "je referencni";
        Debug.WriteLine("Typ " + hodnotovy);
        Debug.WriteLine("Assembly:" + type.AssemblyQualifiedName);
    }

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

    public static char[] NejvicVyskytu(string vstup)
    {
        if (string.IsNullOrEmpty(vstup))
            return new char[0];

        char[] znaky = new char[vstup.Length];
        int[] pocet = new int[vstup.Length];
        char[] vysledok;

        int vkladam = 0;

        foreach (char znak in vstup)
        {
            int index = NajdiZnak(znaky, znak);

            if (index == -1)
            {
                znaky[vkladam] = znak;
                pocet[vkladam] = 1;
                vkladam++;
            }
            else
            {
                pocet[index]++;
            }
        }

        int max = 0;

        foreach (int item in pocet)
        {
            if (item > max)
                max = item;
        }

        int pocetMax = 0;
        foreach (int item in pocet)
        {
            if (item == max)
                pocetMax++;
        }

        vysledok = new char[pocetMax];
        int j = 0;
        for (int i = 0; i < pocet.Length; i++)
        {
            if (pocet[i] == max)
            {
                vysledok[j] = znaky[i];
                j++;
            }
        }

        return vysledok;
    }

    private static int NajdiZnak(char[] znaky, char hledam)
    {
        for (int i = 0; i < znaky.Length; i++)
        {
            if (znaky[i] == hledam)
                return i;
        }

        return -1;
    }

    public static char[] NejvicVyskytuLinq(string vstup)
    {
        if (string.IsNullOrEmpty(vstup))
            return new char[0];

        Dictionary<char, int> data = new Dictionary<char, int>();

        foreach (var item in vstup)
        {
            if (data.ContainsKey(item))
                data[item]++;
            else
                data.Add(item, 1);
        }

        int max = data.Values.Max();

        char[] vysledek = data.Where(x => x.Value == max).Select(x => x.Key).ToArray();

        return vysledek;
    }
}
