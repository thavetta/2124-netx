# Lab 7

## Základy definice referenèního typu

V tomto cvièení vytvoøíme jednoduchý referenèní typ, který bude reprezentovat bankovní úèet.
Vytvoøíme si tøídu, která bude obsahovat informace o úètu a bude umìt provádìt jednoduché operace s úètem a kontrolovat zda ty operace lze provést.

### Pøíprava

1. Vytvoøte si nový project typu Class Library.
1. Projekt nazvìte Banka, solution nazvìte BankaSol. Framework zvolte nejvyšší verzi .NET.
1. Do solution pøidejte projekt typu Console Application, který bude sloužit jako testovací aplikace. Nazvìte ho `Testbanky`.
1. V projektu `Testbanky` pøidejte referenci na projekt `Banka`.

### Tøídy v projektu Banka

1. Pøejmenujte soubor Class1.cs na UcetZaklad.cs. potvrïte pøejmenování tøídy.
1. Ujistìte se, že tøída `UcetZaklad` je oznaèena jako public.
1. Vytvoøte soubor StatusUctu.cs, který bude obsahovat deklaraci enumerátoru pro stav úètu.

		namespace Banka;

        public enum StatusUctu
        {
            Aktivny,
            Zablokovany,
            Zruseny
        }

1. Do tøídy úèet pøidejte deklaraci privátních èlenských prvkù pro jméno majitele, stav úètu a zùstatek na úètu.

        private decimal stav;
        private string majitel;
        private StatusUctu status = StatusUctu.Aktivny;

1. Pøidejte metodu NastavMajitele která nastaví èlenský prvek majitel. Pøed nastavením zkontrolujte, že vstup obsahuje zobrazitelný øetìzec.

        public void NastavMajitele(string majitel)
        {
            if (string.IsNullOrWhiteSpace(majitel))
                throw new ArgumentException("Jmeno majitele musí obsahovat viditelné znaky");

            this.majitel = majitel;
        }

1. Pøidejte metodu VratMajitele, která vrátí jméno majitele.

        public string VratMajitele()
		{
			return majitel;
		}

1. Pøidejte metodu VratStav, která vrátí stav úètu.

		public decimal VratStav()
		{
			return stav;
		}

1. Pøidejte metodu Vklad. povolte vklad jen na aktivní úèet. Vloženou èástku pøiètìte k stavu úètu. Vypište info o provedené operaci.

        public void Vklad(decimal castka)
        {
            if (this.status != StatusUctu.Aktivny)
                throw new InvalidOperationException("Operacia na neaktivnom ucte");

            this.stav += castka;
            Console.WriteLine("Na úèet majitele {0} bylo vloženo {1} a stav je {2}", this.majitel, castka, this.stav);
        }

1. Pøidejte metodu Vyber. povolte výbìr jen z aktivního úètu. Zkontrolujte, že na úètu je dostatek penìz. Vypište info o provedené operaci.

		public void Vyber(decimal castka)
        {
            if (this.status != StatusUctu.Aktivny)
                throw new InvalidOperationException("Operace na neaktím úètu není povolena");

            if (this.stav < castka)
                throw new InvalidOperationException("Nedostateèné krytí na úètu");

            this.stav -= castka;
            Console.WriteLine("Z úètu majitele {0} bylo vybráno {1} a stav je {2}",
                this.majitel, castka, this.stav);
        }

1. V .NET svìtì má každý typ jako pøedka typ Object a od nìj zdìdí metodu ToString. Pøepište metodu ToString tak, aby vracela informace o úètu.
Pozor na povinné slùvko `override`. Bez nìj by to korektnì nefungovalo. Tuto metodu použije napø. Console.WriteLine, pokud by dostal jako parametr instanci úètu.

		public override string ToString()
        {
            return majitel + " - " + stav;
        }

1. Zkuste build a ovìøte že probìhne bez chyb.

### Test v aplikaci TestBanky

1. V `program.cs` udìlejte kód, který vytvoøí alespoò dvì instance úètù.
1. Nastavte úètùm jméno majitele
1. Vložte na úèet nìjaké èástky, mùžete i na nìkolik volání.
1. Vyberte z úètu nìjaké èástky, mùžete i na nìkolik volání.
1. Vypište úèty na konzoli.
1. Zkuste vybrat víc penìz než je na úètu. 
1. Spuse aplikaci a projdìte výstup.

### Závìreèné otázky

1. Jak vnímáte metody pro nastavení a získání hodnoty èlenských promìnných?
1. Jaké metody podle Vás aktuálnì tøídì chybí?
1. Nebylo by lepší použít pro testování Unit testy, než funkènost ovìøovat v konzolové aplikaci?