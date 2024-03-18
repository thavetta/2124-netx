namespace Osoby
{
    public class Osoba
    {
        public long Id { get;}
        public string Jmeno { get; set; }
        public string Mesto { get; set; }
        public int Plat { get; set; }

        public Osoba(long id)
        {
            Id = id;
            Console.WriteLine("Konstruktor Osoba");
        }

        public string SpocitejData()
        {
            //Zaloguj
            return SpocitejDataInternal();
        }

        protected virtual string SpocitejDataInternal()
        {
            return $"{Jmeno} - {Mesto}";
        }

        public override string ToString()
        {
            return $"{Id} - {Jmeno} - {Mesto}";
        }
    }

    public class Pracovnik : Osoba
    {
        public string Zarazeni { get; set; }

        public Pracovnik(long id) : base(id)
        {
            Console.WriteLine("Konstruktor Pracovnik");
        }

        protected override string SpocitejDataInternal()
        {
            return $"{Jmeno} - {Mesto} - {Zarazeni}";
        }
    }
}