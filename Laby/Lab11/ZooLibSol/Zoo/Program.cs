using ZooLib;

List<Zvire> seznam = new()
            {
                new Slon() { Jmeno = "Franta", Vek = 10},
                new Klokan() { Jmeno = "Baltazar", Vek = 5},
                new Papagaj() { Jmeno = "Kral", Vek = 45},
                new Papagaj() { Jmeno = "Kralovna", Vek = 35},
                new Kun() { Jmeno = "Frantiska", Vek = 4}
            };

ObjednavacJidla objednavac = new();

objednavac.PripravRanniObjednavku(seznam);

objednavac.PripravVecerniObjednavku(seznam);
