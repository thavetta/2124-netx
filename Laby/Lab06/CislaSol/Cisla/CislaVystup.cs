namespace Cisla;

public class CislaVystup : IVystupCisel
{
    public void VypisCisel(int[] data, int pocetNaRadek, TextWriter vystup)
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
                vystup.Write(", ");
            }

            vystup.Write(cislo);
            pocet++;

            // pokud dosáhnu počtu čísel na řádek, odřádkuji a obnovím řídící proměnné
            if (pocet == pocetNaRadek)
            {
                start = true;
                pocet = 0;
                vystup.WriteLine();
            }

        }
    }
}