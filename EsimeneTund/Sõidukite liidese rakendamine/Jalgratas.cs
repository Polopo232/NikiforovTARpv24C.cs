namespace EsimeneTund.Auto;

public class Jalgratas : ISõiduk
{
    private double vahemaaKm;

    public Jalgratas(double vahemaaKm)
    {
        this.vahemaaKm = vahemaaKm;
    }

    public double ArvutaKulu()
    {
        return (vahemaaKm * 28);
    }

    public double ArvutaVahemaa()
    {
        return vahemaaKm;
    }
    public override string ToString()
    {
        return $"Jalgratas, Vahemaa: {ArvutaVahemaa()} km, Kulu: {ArvutaKulu()} kcal";
    }
}