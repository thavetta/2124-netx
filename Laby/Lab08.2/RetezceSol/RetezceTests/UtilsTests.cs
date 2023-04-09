using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retezce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retezce.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        public void VratOtocenyTest()
        {
            string vstup = "pokus";
            string ocekavam = "sukop";
            Utils.VypisTyp(vstup);

            string vysledek = Utils.VratOtoceny(vstup);
            Assert.AreEqual(ocekavam, vysledek);
        }

        [TestMethod()]
        public void NejvicVyskytuTest1()
        {
            string vstup = "pokus";
            char[] ocekavam = { 'p','o','k','u','s' };
            char[] vysledek = Utils.NejvicVyskytu(vstup);
            Assert.AreEqual(ocekavam[0], vysledek[0]);
            Assert.AreEqual(ocekavam[1], vysledek[1]);
            Assert.AreEqual(ocekavam[2], vysledek[2]);
            Assert.AreEqual(ocekavam[3], vysledek[3]);
            Assert.AreEqual(ocekavam[4], vysledek[4]);
        }

        [TestMethod()]
        public void NejvicVyskytuTest2()
        {
            string vstup = "mama ma male boty";
            char[] ocekavam = { 'm', 'a' };
            char[] vysledek = Utils.NejvicVyskytu(vstup);
            Assert.AreEqual(ocekavam[0], vysledek[0]);
            Assert.AreEqual(ocekavam[1], vysledek[1]);
            Assert.AreEqual(ocekavam.Length, vysledek.Length);
        }

        [TestMethod()]
        public void VypisTyp_Test()
        {
            int cislo = 5;
            long cislo2 = 5L;
            string retezec = "retezec";
            int[] pole = new int[5];

            Utils.VypisTyp(cislo);
            Utils.VypisTyp(cislo2);
            Utils.VypisTyp(retezec);
            Utils.VypisTyp(pole);
        }
    }
}