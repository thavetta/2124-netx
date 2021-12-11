namespace ZooLib
{
    public abstract class Zvire : IJidlo
    {
        public abstract string RanniDavka();
        public abstract string VecerniDavka();

        public string Jmeno { get; set; }
        public int Vek { get; set; }
    }
}
