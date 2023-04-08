using Cisla;
// See https://aka.ms/new-console-template for more information

IVypocty vypocty = new Pocitadlo();
IVstupCisel vstup = new CislaVstup();
IVystupCisel vystup = new CislaVystup();

int a = vstup.VstupCisla("Zadejte první číslo");
int b = vstup.VstupCisla("Zadejte druhé číslo");

Console.WriteLine($"NSD({a},{b})={vypocty.NSD(a, b)}");
Console.WriteLine($"NSN({a},{b})={vypocty.NSN(a, b)}");
Console.WriteLine();

int c = vstup.VstupCisla("Zadejte číslo pro zjištění, zda je prvočíslo");
Console.WriteLine($"Je číslo {c} prvočíslo? {vypocty.JePrvocislo(c)}");
Console.WriteLine();

int d = vstup.VstupCisla("Zadejte číslo pro výpočet faktoriálu");
Console.WriteLine($"Faktoriál čísla {d} je {vypocty.Faktorial(d)}");
Console.WriteLine();

int e = vstup.VstupCisla("Zadejte maximální číslo pro výpis prvočísel");
Console.WriteLine($"Prvočísla do {e} jsou:");
int[] data = vypocty.VratPrvocisla(e);
vystup.VypisCisel(data, 10, Console.Out);