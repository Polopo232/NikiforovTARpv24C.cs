namespace EsimeneTund.Auto;

public class Auto : ISõiduk
{
    private double kütusekulu;
    private double vahemaaKm;

    public Auto(double kütusekulu, double vahemaaKm)
    {
        this.kütusekulu = kütusekulu;
        this.vahemaaKm = vahemaaKm;
    }

    public double ArvutaKulu()
    {
        return (kütusekulu * vahemaaKm) / 100.0;
    }

    public double ArvutaVahemaa()
    {
        return vahemaaKm;
    }
    public override string ToString()
    {
        return $"Auto, Vahemaa: {ArvutaVahemaa()} km, Kulu: {ArvutaKulu()} liitrit";
    }
}