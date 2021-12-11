using Cisla;

namespace Zlomky;

public class Zlomek : IEquatable<Zlomek>, IComparable<Zlomek>, IComparable
{
    public int Citatel { get; }
    public int Jmenovatel { get; }

    public Zlomek(int citatel, int jmenovatel)
    {
        if (jmenovatel == 0)
            throw new DivideByZeroException();

        if (jmenovatel < 0)
        {
            jmenovatel = -jmenovatel;
            citatel = -citatel;
        }

        if (citatel == 0)
        {
            Citatel = 0;
            Jmenovatel = 1;
            return;
        }

        int nsd = Pocitadlo.NSD(Math.Abs(citatel), jmenovatel);

        Citatel = citatel / nsd;
        Jmenovatel = jmenovatel / nsd;
    }

    public override string ToString()
    {
        return $"[{Citatel}/{Jmenovatel}]";
    }

    public static Zlomek operator +(Zlomek z1, Zlomek z2)
    {
        int citatel = z1.Citatel * z2.Jmenovatel + z2.Citatel * z1.Jmenovatel;
        int jmenovatel = z1.Jmenovatel * z2.Jmenovatel;
        return new Zlomek(citatel, jmenovatel);
    }

    public static Zlomek operator -(Zlomek z1, Zlomek z2)
    {
        int citatel = z1.Citatel * z2.Jmenovatel - z2.Citatel * z1.Jmenovatel;
        int jmenovatel = z1.Jmenovatel * z2.Jmenovatel;
        return new Zlomek(citatel, jmenovatel);
    }

    public static Zlomek operator *(Zlomek z1, Zlomek z2)
    {
        int citatel = z1.Citatel * z2.Citatel;
        int jmenovatel = z1.Jmenovatel * z2.Jmenovatel;
        return new Zlomek(citatel, jmenovatel);
    }

    public static Zlomek operator /(Zlomek z1, Zlomek z2)
    {
        if (z2.Jmenovatel == 0)
            throw new DivideByZeroException();
    
        int citatel = z1.Citatel * z2.Jmenovatel;
        int jmenovatel = z1.Jmenovatel * z2.Citatel;
        return new Zlomek(citatel, jmenovatel);
    }

    public static implicit operator Zlomek(int cislo)
    {
        return new Zlomek(cislo, 1);
    }

    public static explicit operator int(Zlomek z)
    {
        return z.Citatel / z.Jmenovatel;
    }

    public bool Equals(Zlomek? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Citatel == other.Citatel && Jmenovatel == other.Jmenovatel;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Zlomek)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Citatel, Jmenovatel);
    }

    public static bool operator ==(Zlomek? left, Zlomek? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Zlomek? left, Zlomek? right)
    {
        return !Equals(left, right);
    }

    public int CompareTo(Zlomek? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;

        var zlomek = this - other;
        return zlomek.Citatel;
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is Zlomek other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Zlomek)}");
    }

    public static bool operator <(Zlomek? left, Zlomek? right)
    {
        return Comparer<Zlomek>.Default.Compare(left, right) < 0;
    }

    public static bool operator >(Zlomek? left, Zlomek? right)
    {
        return Comparer<Zlomek>.Default.Compare(left, right) > 0;
    }

    public static bool operator <=(Zlomek? left, Zlomek? right)
    {
        return Comparer<Zlomek>.Default.Compare(left, right) <= 0;
    }

    public static bool operator >=(Zlomek? left, Zlomek? right)
    {
        return Comparer<Zlomek>.Default.Compare(left, right) >= 0;
    }
}