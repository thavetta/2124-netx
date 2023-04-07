# Lab 4.2
## Z�kladn� pr�ce s v�jimkami
V tomto cvi�en� se pokus�me zajistit zpracov�n� vstupu od u�ivatele tak, �e zajist�me kontrolu zadan�ho �et�zce.
Pokud u�ivatel zad� n�co, co nen� ��slo, tak se vyp�e upozorn�n� a aplikace vyzve u�ivatele aby zadal ��slo znovu.
Pokra�ujte v pr�ci na projektu z p�edchoz�ho cvi�en� 4.1.

P�i vstupu ��sla m��e doj�t ke dv�ma chyb�m:
1. U�ivatel zad� ��slo, kter� je mimo rozsah pro typ pou�it� v programu (32 bitov� cel� ��slo)
1. U�ivatel zad� �et�zec, kter� bude obsahovat neplatn� znaky nebo po�ad� znak�

Prvn� p��pad vygeneruje v�jimku typu **OverflowException**, kterou m��eme zachytit a zpracovat. 
Druh� p��pad vygeneruje v�jimku typu **FormatException**, kterou m��eme taky zachytit a zpracovat.

Pro zachycen� v�jimky se pou�ije **try catch** blok.

Ot�zkou je, jak vy�e�it opakovan� vy��d�n� vstupu, pokud nastane chyba.

To lze vy�e�it tak, �e cel� vstup od u�ivatele zpracujeme v cyklu, kter� se opakuje, dokud nen� vstup validn�.
Na to pou�ijeme cyklus while, kter� bude m�t v podm�nce konstantu true. Ukon�en� cyklu zajist� break po na�ten� vstupu od u�ivatele.
Pokud byl vstup nevalidn�, na p��kaz break se k�d nedostane.

V�sledek pro vstup prom�nn� a by mohl vypadat takto:

	    while (true)
        {
            Console.WriteLine("Zadejte ��slo a:");
            try
            {
                a = int.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Vstup obsahuje neplatn� znaky");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Vstup je p��li� velk� ��slo");
            }
        }

Ve stejn�m stylu m��eme zpracovat i vstup pro prom�nnou b.

Spus�te aplikaci a ov��te zad�n�m nesmyslu, �e aplikace korektn� zachyt� chyby a nepust� vykon�v�n� k�du d�l.