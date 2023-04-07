# Lab 4.1
## Základní pøíkazy
V tomto cvièení vytvoøíme aplikaci pro vıpoèet nejvìtšího spoleèného dìlitele a nejmenšího spoleèného násobku dvou celıch kladnıch èísel.
Vyuijeme k tomu základní pøíkazy v jazyce C#.
Postup:
1. Vytvoøte novı projekt typu Console Application, zvolte prostøedí .NET 7.
1. V souboru Program.cs vytvoøte dvì promìnné a inicializujte je, napø.:

		int a = 24;
		int b = 16;

1. Aby se nám po vıpoètu NSD zachovala i pùvodní èísla, vytvoøte další promìnné a pøiøaïte jim hodnoty z promìnnıch a a b:

		int x = a;
		int y = b;

1. Protoe vıpoèet dle algoritmu má skonèit kdy jsou obì èísla stejná, pouijte cyklus while

		while (x != y)
		{
			// zde bude vıpoèet
		}

1. V cyklu vytvoøte podmínku, která porovná hodnoty promìnnıch x a y a podle toho pøiøadí menší hodnotu do promìnné x nebo y:

		if (x > y)
		{
			x -= y;
		}
		else
		{
			y -= x;
		}

1. Vısledkem bude NSD, kterı vypíšeme na obrazovku:

		Console.WriteLine($"NSD({a},{b}) = {x}");

1. A ihned mùe bıt spoèítán i NSN, kterı taky vypíšeme na obrazovku:

		Console.WriteLine($"NSN({a},{b}) = " + ((a / x ) * b));

1. Spuste aplikaci a zkontrolujte vısledek.
1. Zmìòte definici promìnné a tak, aby ji šlo zadat z klávesnice. Vyuijte pøíkaz Console.ReadLine().

		Console.Write("Zadejte promìnnou a: ");
		string input = Console.ReadLine();
		int a = int.Parse(input);

1. Stejnì tak zmìòte definici promìnné b.
1. Spuste aplikaci a zkontrolujte vısledek.