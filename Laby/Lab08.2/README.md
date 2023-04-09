# Lab 8.2

## Referenèní typy

V tomto cvièení je cílem ukázat pouití tøídy Debug a reflexe k zjištìní informací o typu

### Pøíprava

1. Zkopírujte si finální projekt z cvièení 8.1 do nového sloky pro Lab 8.2.
2. Ovìøte e fungují všechny stávající testy

### Vytvoøení testu

1. V projektu `RetazceTests` do tøídy `UtilsTests` vytvoøte novı test `VypisTypu_Test`.

1. Vytvoøte v nìm nìkolik promìnnıch rùzného typu. Hodnotové typy je nutno nainicializovat.
1. Pro kadou promìnnou zavolejte metodu `VypisTyp`. Chybu o neexistující metodì ignorujte.
1. Kliknutím na chybu v editoru se vám otevøe okno s moností vygenerovat metodu. Vygenerujte ji.
1. Pøíklad testovací metody

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

1. V projektu `Retazce` do tøídy `Utils` doplòte na zaèátek souboru

        using System.Diagnostics;

    To umoní pouít typ Debug v implementaci metody.

1. Najdìte vygenerovanou metodu VypisTypu a opravte parametr na object.
1. Smate vygenerované tìlo metody.
1. Parametr metody bude typu object. Díky tomu lze jako parametr pøedat cokoliv.
1. Kadá promìnná má díky dìdìní z objectu metodu GetType, která vrací typ promìnné.
1. Projdìte si pomocí intellisence nebo dokumentace tøídu Type.
1. Pouijte vlastnost FullName k vıpisu typu vèetnì namespace
1. Pomocí vlastnosti IsValueType zjistìte zda je typ hodnotovı nebo referenèní
1. Pomocí vlastnosti AssemblyQualifiedName zjistìte jméno assembly, ve kterém je typ definován
1. Informace vypište pomocí tøídy Debug a její metody WriteLine. To vypíše vıstup do Debug okna
1. Vısledná metody bude vypadat takto:

        public static void VypisTyp(object prom)
        {
            Type type = prom.GetType();
            Debug.WriteLine("Jmeno typu:" + type.FullName);
            string urceniTypu = type.IsValueType ? "je hodnotovy" : "je referencni";
            Debug.WriteLine("Typ " + urceniTypu);
            Debug.WriteLine("Assembly:" + type.AssemblyQualifiedName);
        }

1. Spuste test metody a ovìøte e skonèí OK. Musí, protoe tam není ádnı Assert test.
1. Otevøete okno Debug a zkontrolujte vıstup. Mìlo by se v nìm najít nìco takovéto:

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

    Záleet samozøejmì bude na tom, jaké promìnné v testu pøipravíte.

### Otázky

1. Co si myslíte o vıpisu typu pomocí Debug.WriteLine? Je to vhodné pro automatické testování?
1. Má nìjakou vıhodu vytvoøení nejdøív testù a a následnì implementace metod?