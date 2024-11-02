namespace ZooLib
{
    public class ObjednavacJidla
    {
        public void PripravRanniObjednavku(IEnumerable<IJidlo> seznam, StreamWriter vystup = Console.Out)
        {
            vystup.WriteLine("Objednávka na ráno:");
            foreach (IJidlo item in seznam)
            {
                vystup.WriteLine(item.RanniDavka());
            }
            vystup.WriteLine("*********************");
        }

        public void PripravVecerniObjednavku(IEnumerable<IJidlo> seznam, StreamWriter vystup = Console.Out)
        {
            vystup.WriteLine("Objednávka na večer:");
            foreach (IJidlo item in seznam)
            {
                vystup.WriteLine(item.VecerniDavka());
            }
            vystup.WriteLine("*********************");
        }
    }
}
