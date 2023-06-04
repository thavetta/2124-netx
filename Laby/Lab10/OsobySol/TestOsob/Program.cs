using Osoby;

var seznam = VratSeznam();

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