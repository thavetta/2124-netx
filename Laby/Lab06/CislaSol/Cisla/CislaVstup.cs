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
                Console.WriteLine("zadané číslo obsahuje neplatné znaky, zkuste to znovu.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("zadané číslo je příliš velké, zkuste to znovu.");
            }
        }
        return cislo;
    }

    public int VstupCisla(StreamReader reader)
    {
        return int.Parse(reader.ReadLine());
    }

}