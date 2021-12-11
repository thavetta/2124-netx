# Lab 3
## Základní práce s hodnotovým typem
V tomto cvičení vytvoříte aplikaci, která vypíše základní operace mezi dvěmi čísly.
1. Spusťte aplikaci Visual Studio (nejvyšší možnou verzi). Pozor, neplést s aplikací Visual Studio Code.
1. V první nabídce vyberte, že chcete vytvořit Console App
1. Jako název projektu zadejte PrvniApp, vyberte složku kam se má projekt uložit a název Solution nastavte na PrvniAppSol
1. Cílovou platformu vyberte nejvyšší aktuální verzi .NET
1. V souboru program.cs odstraňte veškerý připravený kód
1. Zadejte kód, kterým vytvoříte proměnné a b, obě typu int a přiřaďte jim nějakou rozumnou hodnotu (číslo od 1 do 20)

        int a = 10;
        int b = 15;
        
1. Pomocí Console.WriteLine vypište výsledek různých operací. Jako vzor můžete použít příklad s operací +

        Console.WriteLine($"{a} + {b} = {a + b}");
        
1. Ve stejném duchu vypište operace -,*,/,>>,<<
1. Stiskem klávesy F5 spustíte aplikaci. mělo by se otevřít cmdline okno a vypsat zadané výpočty.

## Extra zadání
K načtení čehokoliv z klávesnice slouží Console.ReadLine(). tato metoda ale vrací řetězec, ne číslo. Proto je nutné použít ještě metodu Parse() typu int, která převede řetězec na celé číslo. Pro proměnnou a by to mohlo vypadat takto:

        Console.WriteLine("Zadejte číslo a:");
        int a = int.Parse(Console.ReadLine());
        
Stejně postupujte i u b. Spusťte aplikaci a ověřte funkčnost.        
