namespace ZooLib
{
    public class ObjednavacJidla
    {
        public void PripravRanniObjednavku(IEnumerable<IJidlo> seznam)
        {
            Console.WriteLine("Objednávka na ráno:");
            foreach (IJidlo item in seznam)
            {
                Console.WriteLine(item.RanniDavka());
            }
            Console.WriteLine("*********************");
        }

        public void PripravVecerniObjednavku(IEnumerable<IJidlo> seznam)
        {
            Console.WriteLine("Objednávka na večer:");
            foreach (IJidlo item in seznam)
            {
                Console.WriteLine(item.VecerniDavka());
            }
            Console.WriteLine("*********************");
        }
    }
}
