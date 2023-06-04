# Lab 9

## Pou�it� vlastnost� a indexeru

V tomto cvi�en� je c�lem uk�zat v�hody pou��v�n� vlastnost� (Property) pro p��stup k �lensk�m prvk�m t��dy a vyu�it� indexer� pro p��stup k dat�m objektu.

### P��prava

1. Zkop�rujte si fin�ln� projekt z cvi�en� 7 do nov�ho slo�ky pro Lab 9
2. Ov��te �e je aplikace funk�n�

### Vlastnosti (Property)

1. Otev�te si soubor `UcetZaklad.cs`.
1. Najd�te k�d metod `NastavMajitele` a `VratMajitele`.
1. Vytvo�te novou vlastnost (propertu) typu string s n�zvem `Majitel`.
1. Vlastnost bude m�t k�d jak pro get, tak i pro set. Zde vyu�ijte jako z�klad k�d z p�vodn�ch metod.
1. V�sledek by m�l b�t zhruba takov�to (defaltn� nastaven� prvku majitel berte jako vtip):

		protected string majitel = "Tajuplny";

        public string Majitel
        {
            get { return majitel; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Hodnota vlastnosti Majitel nem��e b�t pr�zdn�");
                majitel = value;
            }
        }

1. Pro Stav vytvo�te automatickou property, kter� umo�n� nastavit vlastnost jen samotn� t��d� a potomk�m.

        public decimal Stav { get; protected set; }

1. Pro StatusUctu pou�ijte taky automatickou propertu s vyu�it�m mo�nosti nastavit defaultn� v�choz� hodnotu.

        public StatusUctu Status { get; set; } = StatusUctu.Aktivny;

1. Zru�te z k�du deklaraci �lensk�ch prvk� `stav` a `status`. U `majitel` nastavte p��stup na protected.
1. D�le zru�te metody `NastavMajitele` a `VratMajitele`.
1. Ve zb�vaj�c�ch metod�ch opravte k�d, aby neodkazoval na zru�en� �lensk� prvky ale na nov� vlastnosti (property).
1. Ov��te funk�nost aplikace.

### ��slo ��tu

1. Do t��dy `UcetZaklad` p�idejte vlastnost (property) `CisloUctu` typu `int`, kter� bude m�t pouze get. To znamen�, �e ho lze nastavit jen v konstruktoru a pak u� ho nejde zm�nit.
1. P�idejte do t��dy statick� �lensk� prvek `dalsiUcet` typu `int` a nastavte ho na 1.
1. Do konstruktoru p�idejte k�d, kter� nastav� vlastnost `CisloUctu` na hodnotu `dalsiUcet` a potom zv��� hodnotu `dalsiUcet` o 1.
1. K�d by m�l vypadat asi takto:

        private static int dalsiUcet = 1;
    
        public UcetZaklad()
        {
            CisloUctu = dalsiUcet;
            dalsiUcet++;
        }
        
        public int CisloUctu { get; }

1. Do v�pisu v metod�ch Vklad a Vyber p�idejte v�pis ��sla ��tu. Nap� ve Vklad by v�stup mohl b�t:

        Console.WriteLine($"Na ��et {CisloUctu} majitele {majitel} bylo vlo�eno {castka} a stav je {Stav}");

1. Ov��te funk�nost aplikace.

### Indexer

1. Zkop�rujte si lab 8.2 do slo�ky pro lab 9.
1. Ov��te �e je v�e funk�n�.
1. Do test projektu p�idejte novou t��du `PocitaciStringTest` a do n� p�idejte testy pro indexery.
1. Test na indexer vracej�c� po�et v�skyt� znaku by mohl vypadat takto:

        [TestMethod]
        public void PocitaniTest1()
        {
            PocitaciString pocitac = new();
            pocitac.Retezec = "mama ma maso";

            int ocekavam = 4;
            int vysledek = pocitac['m'];
            Assert.AreEqual(ocekavam, vysledek);
        }

1. Druh� test na klasick� indexer �et�zce

        [TestMethod]
        public void PocitaniTest2()
        {
            PocitaciString pocitac = new();
            pocitac.Retezec = "mama ma maso";

            char ocekavam = 'a';
            char vysledek = pocitac[1];
            Assert.AreEqual(ocekavam, vysledek);
        }

1. P�idejte do projektu Retezce novou t��du `PocitaciString` a do n� p�idejte automatickou vlastnost `Retezec` typu `string`.
1. D�le p�idejte indexer, kter� bude vracet po�et v�skyt� zadan�ho znaku v �et�zci. Nap�:

		public int this[char znak]
		{
			get
			{
				int pocet = 0;
				foreach (char item in Retezec)
				{
					if (item == znak)
						pocet++;
				}
				return pocet;
			}
		}

1. A samoz�ejm� je�t� indexer pro v�pis znaku na dan� pozici. Zde vyu�ijeme klasick� indexer stringu.

        public char this[int index]
		{
			get { return Retezec[index]; }
		}

1. Ov��te pomoc� test�, �e oba indexery funguj�.

### Ot�zky na zamy�len�

1. Jak� je rozd�l mezi vlastnost� (property) a �lensk�m prvkem (field)?
1. Jak� je rozd�l mezi automatickou a klasickou vlastnost�?
1. V p��kladu s indexerem a po��t�n�m znak� v �et�zci je pou�it foreach p�i ka�d�m vol�n�. Byla by cesta jak to optimalizovat? 