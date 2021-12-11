// See https://aka.ms/new-console-template for more information
int a;
int b;

while (true)
{
    Console.WriteLine("Zadejte číslo a:");
    try
    {
        a = int.Parse(Console.ReadLine());
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("Vstup obsahuje neplatné znaky");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Vstup je příliš velké číslo");
    }
}

while (true)
{
    Console.WriteLine("Zadejte číslo b:");
    try
    {
        b = int.Parse(Console.ReadLine());
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("Vstup obsahuje neplatné znaky");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Vstup je příliš velké číslo");
    }
}

int x = a;
int y = b;

//Algoritmus NSD
while (x != y)
    if (x > y)
        x -= y;
    else
        y -= x;

Console.WriteLine("NSD čísel {0} a {1} je {2}", a, b, x);

Console.WriteLine($"NSN čísel {a} a {b} je {a * b / x}");

