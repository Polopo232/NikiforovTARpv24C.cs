namespace EsimeneTund.Auto;

public class Buss : ISõiduk
{
    private double kütusekuluL100Km;
    private double vahemaaKm;
    private int reisijateArv;

    public Buss(double kütusekuluL100Km, double vahemaaKm, int reisijateArv)
    {
        this.kütusekuluL100Km = kütusekuluL100Km;
        this.vahemaaKm = vahemaaKm;
        this.reisijateArv = reisijateArv > 0 ? reisijateArv : 1;
    }

    public double ArvutaKulu()
    {
        double kogukulu = (kütusekuluL100Km * vahemaaKm) / 100.0;
        return kogukulu / reisijateArv;
    }

    public double ArvutaVahemaa()
    {
        return vahemaaKm;
    }
    public override string ToString()
    {
        return $"Buss, Vahemaa: {ArvutaVahemaa()} km, Kulu: {ArvutaKulu()} liitrit/reisija";
    }
}