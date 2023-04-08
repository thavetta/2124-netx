# Lab 7

## Z�klady definice referen�n�ho typu

V tomto cvi�en� vytvo��me jednoduch� referen�n� typ, kter� bude reprezentovat bankovn� ��et.
Vytvo��me si t��du, kter� bude obsahovat informace o ��tu a bude um�t prov�d�t jednoduch� operace s ��tem a kontrolovat zda ty operace lze prov�st.

### P��prava

1. Vytvo�te si nov� project typu Class Library.
1. Projekt nazv�te Banka, solution nazv�te BankaSol. Framework zvolte nejvy��� verzi .NET.
1. Do solution p�idejte projekt typu Console Application, kter� bude slou�it jako testovac� aplikace. Nazv�te ho `Testbanky`.
1. V projektu `Testbanky` p�idejte referenci na projekt `Banka`.

### T��dy v projektu Banka

1. P�ejmenujte soubor Class1.cs na UcetZaklad.cs. potvr�te p�ejmenov�n� t��dy.
1. Ujist�te se, �e t��da `UcetZaklad` je ozna�ena jako public.
1. Vytvo�te soubor StatusUctu.cs, kter� bude obsahovat deklaraci enumer�toru pro stav ��tu.

		namespace Banka;

        public enum StatusUctu
        {
            Aktivny,
            Zablokovany,
            Zruseny
        }

1. Do t��dy ��et p�idejte deklaraci priv�tn�ch �lensk�ch prvk� pro jm�no majitele, stav ��tu a z�statek na ��tu.

        private decimal stav;
        private string majitel;
        private StatusUctu status = StatusUctu.Aktivny;

1. P�idejte metodu NastavMajitele kter� nastav� �lensk� prvek majitel. P�ed nastaven�m zkontrolujte, �e vstup obsahuje zobraziteln� �et�zec.

        public void NastavMajitele(string majitel)
        {
            if (string.IsNullOrWhiteSpace(majitel))
                throw new ArgumentException("Jmeno majitele mus� obsahovat viditeln� znaky");

            this.majitel = majitel;
        }

1. P�idejte metodu VratMajitele, kter� vr�t� jm�no majitele.

        public string VratMajitele()
		{
			return majitel;
		}

1. P�idejte metodu VratStav, kter� vr�t� stav ��tu.

		public decimal VratStav()
		{
			return stav;
		}

1. P�idejte metodu Vklad. povolte vklad jen na aktivn� ��et. Vlo�enou ��stku p�i�t�te k stavu ��tu. Vypi�te info o proveden� operaci.

        public void Vklad(decimal castka)
        {
            if (this.status != StatusUctu.Aktivny)
                throw new InvalidOperationException("Operacia na neaktivnom ucte");

            this.stav += castka;
            Console.WriteLine("Na ��et majitele {0} bylo vlo�eno {1} a stav je {2}", this.majitel, castka, this.stav);
        }

1. P�idejte metodu Vyber. povolte v�b�r jen z aktivn�ho ��tu. Zkontrolujte, �e na ��tu je dostatek pen�z. Vypi�te info o proveden� operaci.

		public void Vyber(decimal castka)
        {
            if (this.status != StatusUctu.Aktivny)
                throw new InvalidOperationException("Operace na neakt�m ��tu nen� povolena");

            if (this.stav < castka)
                throw new InvalidOperationException("Nedostate�n� kryt� na ��tu");

            this.stav -= castka;
            Console.WriteLine("Z ��tu majitele {0} bylo vybr�no {1} a stav je {2}",
                this.majitel, castka, this.stav);
        }

1. V .NET sv�t� m� ka�d� typ jako p�edka typ Object a od n�j zd�d� metodu ToString. P�epi�te metodu ToString tak, aby vracela informace o ��tu.
Pozor na povinn� sl�vko `override`. Bez n�j by to korektn� nefungovalo. Tuto metodu pou�ije nap�. Console.WriteLine, pokud by dostal jako parametr instanci ��tu.

		public override string ToString()
        {
            return majitel + " - " + stav;
        }

1. Zkuste build a ov��te �e prob�hne bez chyb.

### Test v aplikaci TestBanky

1. V `program.cs` ud�lejte k�d, kter� vytvo�� alespo� dv� instance ��t�.
1. Nastavte ��t�m jm�no majitele
1. Vlo�te na ��et n�jak� ��stky, m��ete i na n�kolik vol�n�.
1. Vyberte z ��tu n�jak� ��stky, m��ete i na n�kolik vol�n�.
1. Vypi�te ��ty na konzoli.
1. Zkuste vybrat v�c pen�z ne� je na ��tu. 
1. Spus�e aplikaci a projd�te v�stup.

### Z�v�re�n� ot�zky

1. Jak vn�m�te metody pro nastaven� a z�sk�n� hodnoty �lensk�ch prom�nn�ch?
1. Jak� metody podle V�s aktu�ln� t��d� chyb�?
1. Nebylo by lep�� pou��t pro testov�n� Unit testy, ne� funk�nost ov��ovat v konzolov� aplikaci?