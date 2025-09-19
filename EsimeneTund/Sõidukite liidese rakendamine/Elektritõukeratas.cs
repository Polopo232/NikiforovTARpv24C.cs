using EsimeneTund.Auto;

namespace EsimeneTund.Sõidukite_liidese_rakendamine;

public class Elektritõukeratas : ISõiduk
{
    private double energiakuluL100Km;
    private double vahemaaKm;

    public Elektritõukeratas(double energiakuluL100Km, double vahemaaKm) {
    
        this.energiakuluL100Km = energiakuluL100Km;
        this.vahemaaKm = vahemaaKm;
    }

    public double ArvutaKulu()
    {
        return (energiakuluL100Km * vahemaaKm);
    }

    public double ArvutaVahemaa()
    {
        return vahemaaKm;
    }
    public override string ToString()
    {
        return $"Elektritõukeratas, Vahemaa: {ArvutaVahemaa()} km, Kulu: {ArvutaKulu()} kWh";
    }
}
