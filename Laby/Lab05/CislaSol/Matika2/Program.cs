using Cisla;
// See https://aka.ms/new-console-template for more information

IVypocty vypocty = new Pocitadlo();

int a = vypocty.VstupCisla("Zadejte první číslo");
int b = vypocty.VstupCisla("Zadejte druhé číslo");

Console.WriteLine($"NSD({a},{b})={vypocty.NSD(a, b)}");
Console.WriteLine($"NSN({a},{b})={vypocty.NSN(a, b)}");
Console.WriteLine();

int c = vypocty.VstupCisla("Zadejte číslo pro zjištění, zda je prvočíslo");
Console.WriteLine($"Je číslo {c} prvočíslo? {vypocty.JePrvocislo(c)}");
Console.WriteLine();

int d = vypocty.VstupCisla("Zadejte číslo pro výpočet faktoriálu");
Console.WriteLine($"Faktoriál čísla {d} je {vypocty.Faktorial(d)}");