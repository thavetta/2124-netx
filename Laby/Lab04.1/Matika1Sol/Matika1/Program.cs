// See https://aka.ms/new-console-template for more information

Console.WriteLine("Zadejte číslo a:");
int a = int.Parse(Console.ReadLine());

Console.WriteLine("Zadejte číslo b:");
int b = int.Parse(Console.ReadLine());

int x = a;
int y = b;

//Algoritmus NSD
while (x != y)
    if (x > y)
        x -= y;
    else
        y -= x;

Console.WriteLine("NSD čísel {0} a {1} je {2}",a,b,x);

Console.WriteLine($"NSN čísel {a} a {b} je {a*b/x}");

