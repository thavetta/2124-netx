# Lab 9

## Použití vlastností a indexeru

V tomto cvièení je cílem ukázat výhody používání vlastností (Property) pro pøístup k èlenským prvkùm tøídy a využití indexerù pro pøístup k datùm objektu.

### Pøíprava

1. Zkopírujte si finální projekt z cvièení 7 do nového složky pro Lab 9
2. Ovìøte že je aplikace funkèní

### Vlastnosti (Property)

1. Otevøte si soubor `UcetZaklad.cs`.
1. Najdìte kód metod `NastavMajitele` a `VratMajitele`.
1. Vytvoøte novou vlastnost (propertu) typu string s názvem `Majitel`.
1. Vlastnost bude mít kód jak pro get, tak i pro set. Zde využijte jako základ kód z pùvodních metod.
1. Výsledek by mìl být zhruba takovýto (defaltní nastavení prvku majitel berte jako vtip):

		protected string majitel = "Tajuplny";

        public string Majitel
        {
            get { return majitel; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Hodnota vlastnosti Majitel nemùže být prázdná");
                majitel = value;
            }
        }

1. Pro Stav vytvoøte automatickou property, která umožní nastavit vlastnost jen samotné tøídì a potomkùm.

        public decimal Stav { get; protected set; }

1. Pro StatusUctu použijte taky automatickou propertu s využitím možnosti nastavit defaultní výchozí hodnotu.

        public StatusUctu Status { get; set; } = StatusUctu.Aktivny;

1. Zrušte z kódu deklaraci èlenských prvkù `stav` a `status`. U `majitel` nastavte pøístup na protected.
1. Dále zrušte metody `NastavMajitele` a `VratMajitele`.
1. Ve zbývajících metodách opravte kód, aby neodkazoval na zrušené èlenské prvky ale na nové vlastnosti (property).
1. Ovìøte funkènost aplikace.

### Èíslo úètu

1. Do tøídy `UcetZaklad` pøidejte vlastnost (property) `CisloUctu` typu `int`, které bude mít pouze get. To znamená, že ho lze nastavit jen v konstruktoru a pak už ho nejde zmìnit.
1. Pøidejte do tøídy statický èlenský prvek `dalsiUcet` typu `int` a nastavte ho na 1.
1. Do konstruktoru pøidejte kód, který nastaví vlastnost `CisloUctu` na hodnotu `dalsiUcet` a potom zvýší hodnotu `dalsiUcet` o 1.
1. Kód by mìl vypadat asi takto:

        private static int dalsiUcet = 1;
    
        public UcetZaklad()
        {
            CisloUctu = dalsiUcet;
            dalsiUcet++;
        }
        
        public int CisloUctu { get; }

1. Do výpisu v metodách Vklad a Vyber pøidejte výpis èísla úètu. Napø ve Vklad by výstup mohl být:

        Console.WriteLine($"Na úèet {CisloUctu} majitele {majitel} bylo vloženo {castka} a stav je {Stav}");

1. Ovìøte funkènost aplikace.

### Indexer

1. Zkopírujte si lab 8.2 do složky pro lab 9.
1. Ovìøte že je vše funkèní.
1. Do test projektu pøidejte novou tøídu `PocitaciStringTest` a do ní pøidejte testy pro indexery.
1. Test na indexer vracející poèet výskytù znaku by mohl vypadat takto:

        [TestMethod]
        public void PocitaniTest1()
        {
            PocitaciString pocitac = new();
            pocitac.Retezec = "mama ma maso";

            int ocekavam = 4;
            int vysledek = pocitac['m'];
            Assert.AreEqual(ocekavam, vysledek);
        }

1. Druhý test na klasický indexer øetìzce

        [TestMethod]
        public void PocitaniTest2()
        {
            PocitaciString pocitac = new();
            pocitac.Retezec = "mama ma maso";

            char ocekavam = 'a';
            char vysledek = pocitac[1];
            Assert.AreEqual(ocekavam, vysledek);
        }

1. Pøidejte do projektu Retezce novou tøídu `PocitaciString` a do ní pøidejte automatickou vlastnost `Retezec` typu `string`.
1. Dále pøidejte indexer, který bude vracet poèet výskytù zadaného znaku v øetìzci. Napø:

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

1. A samozøejmì ještì indexer pro výpis znaku na dané pozici. Zde využijeme klasický indexer stringu.

        public char this[int index]
		{
			get { return Retezec[index]; }
		}

1. Ovìøte pomocí testù, že oba indexery fungují.

### Otázky na zamyšlení

1. Jaký je rozdíl mezi vlastností (property) a èlenským prvkem (field)?
1. Jaký je rozdíl mezi automatickou a klasickou vlastností?
1. V pøíkladu s indexerem a poèítáním znakù v øetìzci je použit foreach pøi každém volání. Byla by cesta jak to optimalizovat? 