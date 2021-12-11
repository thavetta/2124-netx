//Tento příkaz umožní nepsat u statických metod třídy Pocitadlo název třídy
using static Cisla.Pocitadlo;

int a = NactiCislo("Zadej cislo a:");
int b = NactiCislo("Zadej cislo b:");

int nsd = NSD(a, b);
int nsn = NSN(a, b);

Console.WriteLine($"NSD({a},{b}) = {nsd}");
Console.WriteLine($"NSN({a},{b}) = {nsn}");

int x = NactiCislo("Zadej číslo pro test prvočísla:");

string vyrok = JePrvocislo(x) ? "je" : "není";

Console.WriteLine($"Číslo {x} {vyrok} prvočíslo");

int max = NactiCislo("Po jaké číslo chceš prvočísla?");

int[] prvocisla = VratPrvocisla(max);

VypisCisla(prvocisla, 12);
