# Lab 8.1

## Z�klady pr�ce s referen�n�mi typy

C�lem tohoto cvi�en� je sezn�mit se s referen�n�mi typy v jazyce C# a s jejich vyu�it�m.
Vyu�ijeme p�ipraven� Unit Testy, tentokr�t v MS frameworku, kter� pou��v� jin� attributy ne� xUnit.
Princip Unit Test� je stejn� jako v p�edchoz�ch cvi�en�ch.

### P��prava

1. Ve slo�ce s laby najd�te v Lab8.1 slo�ku Start. Z n� si vykop�rujte do pracovn�ho prostoru p�ipravenou Solution `RetazceSol`.
1. Solution obsahuje dva projekty
	
	* `Retezce` - knihovna s implementac� metod pro pr�ci s �et�zci
	* `Retezcetests` - unit testy pomoc� frameworku MS test v. 2

1. Projekt `Retezce` obsahuje t��du `Utils` s p�ipraven�mi metodami, kter� chceme vytvo�it.
1. Projekt `RetezceTests` obsahuje t��du `UtilsTests` s p�ipraven�mi testy, kter� chceme aby skon�ili �sp�chem.
1. Zkuste spustit v�echny testy. Kompilace by m�la prob�hnout OK, ale testy sel�ou.

### Implementace metody VratOtoceny

1. K�d t�to metody umo��uje r�zn� cesty �e�en�. Nejd��v si zkuste vymyslet vlastn� algoritmus jak by se dalo postupovat.
1. Mo�n� �e�en� vych�z� z toho, �e vyu�ijeme t��du StringBuilder a vyskl�d�me �et�zec p�id�v�n�m znak�, kter� z�sk�me p�i proch�zen� pole znak� od konce.
1. Ne� za�nete �et�zec zpracov�vat, otestujte zda nen� null, p��padn� zda nen� pr�zdn�.
1. Vytvo�te si instanci t��dy `StringBuilder` a p�ed�te mu d�lku vstupn�ho �et�zce. Reverzn� �et�zec bude stejn� dlouh� a StringBuilderu tak uleh��me pr�ci.
1. Vyu�ijte metodu `Append` t��dy `StringBuilder` pro p�id�n� znaku na konec �et�zce.
1. Vyu�ijte metodu `ToString` t��dy `StringBuilder` pro p�evod na �et�zec.
1. K�d by mohl vypadat takto:

		public static string VratOtoceny(string vstup)
        {
            if (vstup == null)
                return null;
            if (string.IsNullOrEmpty(vstup))
                return String.Empty;

            StringBuilder sb = new StringBuilder(vstup.Length);

            for (int i = vstup.Length - 1; i >= 0; i--)
            {
                sb.Append(vstup[i]);
            }

            return sb.ToString();
        }

1. Spus�te testy a zkontrolujte, �e v�echny testy pro tuto metodu pro�ly.

### Implementace metody NejvicVyskytu

1. Op�t nejd��ve zkuste vymyslet vlastn� �e�en� a implementovat ho.
1. Mo�n� �e�en� vych�z� z toho, �e vyu�ijeme t��du Dictionary, kter� umo��uje ukl�dat hodnoty podle kl��e. To n�m umo�n� jednodu�e p�i�adit p�smen�m po�et v�skyt�.
1. Ne� za�nete �et�zec zpracov�vat, otestujte zda nen� null, p��padn� zda nen� pr�zdn�.
1. Vytvo�te si instanci t��dy `Dictionary<char, int>`. Typ char bude tzv. kl��, int pak ur�uje ke kl��i nav�zanou hodnotu.
1. Vyu�ijte cyklus `foreach` pro proch�zen� v�ech znak� vstupn�ho �et�zce.
1. Vyu�ijte metodu `ContainsKey` t��dy `Dictionary` pro zji�t�n�, zda ji� v Dictionary je z�znam pro dan� kl��.
1. Pokud ji� z�znam existuje, zv��te hodnotu o 1.
1. Pokud z�znam neexistuje, vlo�te do Dictionary z�znam s kl��em znaku a hodnotou 1.
1. Tato ��st by mohla vypadat takto

        public static char[] NejvicVyskytu(string vstup)
        {
            if (string.IsNullOrEmpty(vstup))
                return new char[0];

            Dictionary<char, int> seznam = new ();

            //Cyklus proch�z� znaky a napo��t�v� v�skyt
            foreach (char znak in vstup)
            {
                if (seznam.ContainsKey(znak))
                    seznam[znak]++;
                else
                    seznam.Add(znak, 1);
            }
        ...

1. Ka�d� Dictionary m� vlastnost Keys - ta zp��stupn� kolekci kl��� a Values - kter� zp��stupn� kolekci hodnot.
1. Te� zjist�me nejvy��� po�et v�skyt�. Vyu�ijeme metodu `Max` t��dy `Math`.
1. K�d by mohl vypadat takto:

        //Najde nejv�t�� v�skyt
        int max = int.MinValue;

        foreach (var value in seznam.Values) 
            max = Math.Max(max, value);

1. Jakmile m�me maximum, pot�ebujeme zjistit kolik je takov�chto znak�. 
1. Proiterujeme op�t kolekci Values a hled�me jen ty co maj� maxim�ln� hodnotu.

        //Najde po�et znak� s nejv�t��m v�skytem
        int pocetMax = 0;
        
        foreach (int item in seznam.Values)
        {
            if (item == max)
                pocetMax++;
        }

1. Vytvo��me si pole o velikosti po�tu znak� s nejv�t��m v�skytem.
1. Projdeme op�t kolekci Values a hled�me znaky s maxim�ln�m v�skytem. Ty pak p�id�me do pole.

        //Vytvo�� v�stupn� pole podle zji�t�n�ho po�tu
        char[] vysledek = new char[pocetMax];

        //Napln� pole znaky s nejv�t��m v�skytem
        int index = 0;

        foreach (KeyValuePair<char, int> item in seznam)
        {
            if (item.Value != max) 
                continue;
            vysledek[index] = item.Key;
            index++;
        }

1. V�sledn� pole vrac�me.

        return vysledek;

1. Ov��te buildem �e nem�te nikde chybu kter� by br�nila kompilaci.
1. Spus�e p�ipraven� testy. M�ly by skon�it �sp�chem.
		