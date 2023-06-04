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
        }

        public override string ToString()
        {
            return $"{Id} - {Jmeno} - {Mesto}";
        }
    }
}