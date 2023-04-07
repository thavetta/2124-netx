# Lab 4.1
## Z�kladn� p��kazy
V tomto cvi�en� vytvo��me aplikaci pro v�po�et nejv�t��ho spole�n�ho d�litele a nejmen��ho spole�n�ho n�sobku dvou cel�ch kladn�ch ��sel.
Vyu�ijeme k tomu z�kladn� p��kazy v jazyce C#.
Postup:
1. Vytvo�te nov� projekt typu Console Application, zvolte prost�ed� .NET 7.
1. V souboru Program.cs vytvo�te dv� prom�nn� a inicializujte je, nap�.:

		int a = 24;
		int b = 16;

1. Aby se n�m po v�po�tu NSD zachovala i p�vodn� ��sla, vytvo�te dal�� prom�nn� a p�i�a�te jim hodnoty z prom�nn�ch a a b:

		int x = a;
		int y = b;

1. Proto�e v�po�et dle algoritmu m� skon�it kdy� jsou ob� ��sla stejn�, pou�ijte cyklus while

		while (x != y)
		{
			// zde bude v�po�et
		}

1. V cyklu vytvo�te podm�nku, kter� porovn� hodnoty prom�nn�ch x a y a podle toho p�i�ad� men�� hodnotu do prom�nn� x nebo y:

		if (x > y)
		{
			x -= y;
		}
		else
		{
			y -= x;
		}

1. V�sledkem bude NSD, kter� vyp�eme na obrazovku:

		Console.WriteLine($"NSD({a},{b}) = {x}");

1. A ihned m��e b�t spo��t�n i NSN, kter� taky vyp�eme na obrazovku:

		Console.WriteLine($"NSN({a},{b}) = " + ((a / x ) * b));

1. Spus�te aplikaci a zkontrolujte v�sledek.
1. Zm��te definici prom�nn� a tak, aby ji �lo zadat z kl�vesnice. Vyu�ijte p��kaz Console.ReadLine().

		Console.Write("Zadejte prom�nnou a: ");
		string input = Console.ReadLine();
		int a = int.Parse(input);

1. Stejn� tak zm��te definici prom�nn� b.
1. Spus�te aplikaci a zkontrolujte v�sledek.