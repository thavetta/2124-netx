// See https://aka.ms/new-console-template for more information
int a = 10;
int b = 3;

// Načtení od uživatele (Extra zadání)
//Console.WriteLine("Zadejte číslo a:");
//a = int.Parse(Console.ReadLine());

//Console.WriteLine("Zadejte číslo b:");
//b = int.Parse(Console.ReadLine());

Console.Write("Součet: ");
Console.WriteLine($"{a} + {b} = {a + b}");

Console.Write("Rozdíl: ");
Console.WriteLine($"{a} - {b} = {a - b}");

Console.Write("Nasobení: ");
Console.WriteLine($"{a} * {b} = {a * b}");

Console.Write("Dělení celočíselné: ");
Console.WriteLine($"{a} / {b} = {a / b}");

Console.Write("Dělení v reálných číslech: ");
Console.WriteLine($"{a} / {b} = {a / (double)b}");

Console.Write("Zbytek: ");
Console.WriteLine($"{a} modulo {b} = {a % b}");

Console.Write("Posun doprava: ");
Console.WriteLine($"{a} posun o {b} bity = {a >> b}");

Console.Write("Posun doleva: ");
Console.WriteLine($"{a} posun o {b} bity = {a << b}");
