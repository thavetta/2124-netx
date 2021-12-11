using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retazce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetezceTests;

[TestClass]
public class PocitaciStringTests
{
    [TestMethod]
    public void PocitaniTest1()
    {
        PocitaciString pocitac = new();
        pocitac.Retezec = "mama ma maso";

        int ocekavam = 4;
        int vysledek = pocitac['m'];
        Assert.AreEqual(ocekavam, vysledek);
    }

    [TestMethod]
    public void PocitaniTest2()
    {
        PocitaciString pocitac = new();
        pocitac.Retezec = "mama ma maso";

        char ocekavam = 'a';
        char vysledek = pocitac[1];
        Assert.AreEqual(ocekavam, vysledek);
    }
}
