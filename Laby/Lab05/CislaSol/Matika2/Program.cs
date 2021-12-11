using Cisla;
// See https://aka.ms/new-console-template for more information

int a = Pocitadlo.NactiCislo("Zadej cislo a:");
int b = Pocitadlo.NactiCislo("Zadej cislo b:");

int nsd = Pocitadlo.NSD(a, b);
int nsn = Pocitadlo.NSN(a, b);

Console.WriteLine($"NSD({a},{b}) = {nsd}");
Console.WriteLine($"NSN({a},{b}) = {nsn}");

int x = Pocitadlo.NactiCislo("Zadej číslo pro test prvočísla:");

string vyrok = Pocitadlo.JePrvocislo(x) ? "je" : "není";

Console.WriteLine($"Číslo {x} {vyrok} prvočíslo");
