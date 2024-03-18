using Osoby;
using System.Text;

Osoba pracovnik = new Pracovnik(55) { Jmeno = "Tom", Mesto = "Brno", Zarazeni = "Vyvoj"};

Console.WriteLine(pracovnik.SpocitejData());

var seznam = VratSeznam();

using StreamReader vstup2 = File.OpenText("data2.txt");

using (StreamReader vstup = File.OpenText("data.txt"))
{
    string radek;
    while ((radek = vstup.ReadLine()) != null)
    {
        Console.WriteLine(radek);
    }
}



VypisOsoby(seznam);

VypisOsoby(seznam.Where(o => o.Plat > 40000));

void VypisOsoby(IEnumerable<Osoba> seznam)
{
    foreach (var osoba in seznam)
    {
        Console.WriteLine(osoba);
    }
}

Osoba[] VratSeznam()
{
    return new[]
    {
        new Osoba(1) { Jmeno = "Tomas", Mesto = "Brno", Plat = 40000 },
        new Osoba(2) { Jmeno = "Jana", Mesto = "Ostrava", Plat = 45000 },
        new Osoba(3) { Jmeno = "Karel", Mesto = "Plzen", Plat = 38000 },
        new Osoba(4) { Jmeno = "Ondrej", Mesto = "Poprad", Plat = 44000 },
        new Osoba(5) { Jmeno = "Eva", Mesto = "Liberec", Plat = 41000 },
    };

}