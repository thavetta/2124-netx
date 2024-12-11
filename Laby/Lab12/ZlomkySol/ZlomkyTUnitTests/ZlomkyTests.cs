using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zlomky;
using TUnit.Core;

namespace ZlomkyTUnitTests;

public class ZlomkyTests
{
        [Test]
        public async Task Konstruktor_Korektni_VytvoriZlomek()
        {
            Zlomek z = new Zlomek(4, 8);
            await Assert.That(z.Citatel).IsEqualTo(1);
            await Assert.That(z.Jmenovatel).IsEqualTo(2);
        }
}
