# Lab12

## Přetížení operátorů

V tomto cvičení zkusíme vytvořit strukturu Zlomek, která bude reprezentovat klasický zlomek (racionální čísla).
Strukturu naučíme základní operace +, -, *, / a dále rovnost, nerovnost a porovnávání větší menší.
Umožníme i přetypování mezi Zlomkem a celými čísly (int).

### Vytvoření knihovny Zlomky

1. Vytvořte nový projekt typu Class Library pro jazyk C# a pojmenujte jej `Zlomky`.
1. Připravený `Class1` změňte na struct a přejmenujte na `Zlomek`.
1. Při práci se zlomky potřebujeme mít zlomky v tzv. základním tvaru, kdy čitatel a jmenovatel nejdou krátit. Tedy 2/4 = 1/2. K tomu budeme potřebovat funkci pro největšího společného dělitele. Tu už jsme dělali v předchozích labech a tak ji tady použijeme. Přidejte do projektu referenci na `Cisla.dll` z labu 6. Dll najdete ve složce bin příslušného labu.
1. 