# Lab 4.2
## Základní práce s vıjimkami
V tomto cvièení se pokusíme zajistit zpracování vstupu od uivatele tak, e zajistíme kontrolu zadaného øetìzce.
Pokud uivatel zadá nìco, co není èíslo, tak se vypíše upozornìní a aplikace vyzve uivatele aby zadal èíslo znovu.
Pokraèujte v práci na projektu z pøedchozího cvièení 4.1.

Pøi vstupu èísla mùe dojít ke dvìma chybám:
1. Uivatel zadá èíslo, které je mimo rozsah pro typ pouitı v programu (32 bitové celé èíslo)
1. Uivatel zadá øetìzec, kterı bude obsahovat neplatné znaky nebo poøadí znakù

První pøípad vygeneruje vıjimku typu **OverflowException**, kterou mùeme zachytit a zpracovat. 
Druhı pøípad vygeneruje vıjimku typu **FormatException**, kterou mùeme taky zachytit a zpracovat.

Pro zachycení vıjimky se pouije **try catch** blok.

Otázkou je, jak vyøešit opakované vyádání vstupu, pokud nastane chyba.

To lze vyøešit tak, e celı vstup od uivatele zpracujeme v cyklu, kterı se opakuje, dokud není vstup validní.
Na to pouijeme cyklus while, kterı bude mít v podmínce konstantu true. Ukonèení cyklu zajistí break po naètení vstupu od uivatele.
Pokud byl vstup nevalidní, na pøíkaz break se kód nedostane.

Vısledek pro vstup promìnné a by mohl vypadat takto:

	    while (true)
        {
            Console.WriteLine("Zadejte èíslo a:");
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
                Console.WriteLine("Vstup je pøíliš velké èíslo");
            }
        }

Ve stejném stylu mùeme zpracovat i vstup pro promìnnou b.

Spuste aplikaci a ovìøte zadáním nesmyslu, e aplikace korektnì zachytí chyby a nepustí vykonávání kódu dál.