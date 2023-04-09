# Lab 8.2

## Referen�n� typy

V tomto cvi�en� je c�lem uk�zat pou�it� t��dy Debug a reflexe k zji�t�n� informac� o typu

### P��prava

1. Zkop�rujte si fin�ln� projekt z cvi�en� 8.1 do nov�ho slo�ky pro Lab 8.2.
2. Ov��te �e funguj� v�echny st�vaj�c� testy

### Vytvo�en� testu

1. V projektu `RetazceTests` do t��dy `UtilsTests` vytvo�te nov� test `VypisTypu_Test`.

1. Vytvo�te v n�m n�kolik prom�nn�ch r�zn�ho typu. Hodnotov� typy je nutno nainicializovat.
1. Pro ka�dou prom�nnou zavolejte metodu `VypisTyp`. Chybu o neexistuj�c� metod� ignorujte.
1. Kliknut�m na chybu v editoru se v�m otev�e okno s mo�nost� vygenerovat metodu. Vygenerujte ji.
1. P��klad testovac� metody

        [TestMethod()]
        public void VypisTyp_Test()
        {
            int cislo = 5;
            long cislo2 = 5L;
            string retezec = "retezec";
            int[] pole = new int[5];

            Utils.VypisTyp(cislo);
            Utils.VypisTyp(cislo2);
            Utils.VypisTyp(retezec);
            Utils.VypisTyp(pole);
        }

### Implementace metody

1. V projektu `Retazce` do t��dy `Utils` dopl�te na za��tek souboru

        using System.Diagnostics;

    To umo�n� pou��t typ Debug v implementaci metody.

1. Najd�te vygenerovanou metodu VypisTypu a opravte parametr na object.
1. Sma�te vygenerovan� t�lo metody.
1. Parametr metody bude typu object. D�ky tomu lze jako parametr p�edat cokoliv.
1. Ka�d� prom�nn� m� d�ky d�d�n� z objectu metodu GetType, kter� vrac� typ prom�nn�.
1. Projd�te si pomoc� intellisence nebo dokumentace t��du Type.
1. Pou�ijte vlastnost FullName k v�pisu typu v�etn� namespace
1. Pomoc� vlastnosti IsValueType zjist�te zda je typ hodnotov� nebo referen�n�
1. Pomoc� vlastnosti AssemblyQualifiedName zjist�te jm�no assembly, ve kter�m je typ definov�n
1. Informace vypi�te pomoc� t��dy Debug a jej� metody WriteLine. To vyp�e v�stup do Debug okna
1. V�sledn� metody bude vypadat takto:

        public static void VypisTyp(object prom)
        {
            Type type = prom.GetType();
            Debug.WriteLine("Jmeno typu:" + type.FullName);
            string urceniTypu = type.IsValueType ? "je hodnotovy" : "je referencni";
            Debug.WriteLine("Typ " + urceniTypu);
            Debug.WriteLine("Assembly:" + type.AssemblyQualifiedName);
        }

1. Spus�te test metody a ov��te �e skon�� OK. Mus�, proto�e tam nen� ��dn� Assert test.
1. Otev�ete okno Debug a zkontrolujte v�stup. M�lo by se v n�m naj�t n�co takov�to:

        Jmeno typu:System.Int32
        Typ je hodnotovy
        Assembly:System.Int32, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
        Jmeno typu:System.Int64
        Typ je hodnotovy
        Assembly:System.Int64, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
        Jmeno typu:System.String
        Typ je referencni
        Assembly:System.String, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
        Jmeno typu:System.Int32[]
        Typ je referencni
        Assembly:System.Int32[], System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e

    Z�le�et samoz�ejm� bude na tom, jak� prom�nn� v testu p�iprav�te.

### Ot�zky

1. Co si mysl�te o v�pisu typu pomoc� Debug.WriteLine? Je to vhodn� pro automatick� testov�n�?
1. M� n�jakou v�hodu vytvo�en� nejd��v test� a a� n�sledn� implementace metod?