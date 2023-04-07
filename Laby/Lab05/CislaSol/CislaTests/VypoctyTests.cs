using Cisla;

namespace CislaTests;

public class VypoctyTests
{
    [Theory]
    [InlineData(24, 18, 6)]
    [InlineData(24, 36, 12)]
    [InlineData(29, 6, 1)]
    public void NSD_PlatnyVstup_Vysledek(int a, int b, int ocekavam)
    {
        //Arange
        IVypocty vypocty = new Pocitadlo();
        //Act
        int vysledek = vypocty.NSD(a, b);
        //Assert
        Assert.Equal(ocekavam, vysledek);
    }

    [Theory]
    [InlineData(24, 18, 72)]
    [InlineData(24, 36, 72)]
    public void NSN_PlatnyVstup_Vysledek(int a, int b, int ocekavam)
    {
        //Arange
        IVypocty vypocty = new Pocitadlo();
        //Act
        int vysledek = vypocty.NSN(a, b);
        //Assert
        Assert.Equal(ocekavam, vysledek);
    }

    [Theory]
    [InlineData(5, 120)]
    [InlineData(4, 24)]
    public void Faktorial_PlatnyVstup_Vysledek(int a, int ocekavam)
    {
        //Arange
        IVypocty vypocty = new Pocitadlo();
        //Act
        int vysledek = vypocty.Faktorial(a);
        //Assert
        Assert.Equal(ocekavam, vysledek);
    }

    [Theory]
    [InlineData(5, true)]
    [InlineData(53, true)]
    [InlineData(4, false)]
    public void JePrvocislo_PlatnyVstup_Vysledek(int a, bool ocekavam)
    {
        //Arange
        IVypocty vypocty = new Pocitadlo();
        //Act
        bool vysledek = vypocty.JePrvocislo(a);
        //Assert
        Assert.Equal(ocekavam, vysledek);
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(1)]
    public void JePrvocislo_NeplatnyVstup_Vyjimka(int a)
    {
        //Arange
        IVypocty vypocty = new Pocitadlo();
        //Act
        
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => vypocty.JePrvocislo(a));
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    public void Faktorial_NeplatnyVstup_Vyjimka(int a)
    {
        //Arange
        IVypocty vypocty = new Pocitadlo();
        //Act

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => vypocty.Faktorial(a));
    }

    [Theory]
    [InlineData(-5, 6)]
    [InlineData(8, 0)]
    public void NSD_NeplatnyVstup_Vyjimka(int a, int b)
    {
        //Arange
        IVypocty vypocty = new Pocitadlo();
        //Act

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => vypocty.NSD(a,b));
    }

    [Theory]
    [InlineData(-5, 6)]
    [InlineData(8, 0)]
    public void NSN_NeplatnyVstup_Vyjimka(int a, int b)
    {
        //Arange
        IVypocty vypocty = new Pocitadlo();
        //Act

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => vypocty.NSN(a, b));
    }
}