namespace EsimeneTund;

internal class Inimene
{
    public string eesnimi;
    public int aeg;
    public Inimene() { }

    public Inimene(string eesnimi, int aeg)
    {
        this.eesnimi = eesnimi;
        this.aeg = aeg;
    }
    public void printInfo()
    {
        Console.WriteLine($"Inimene nimi on {eesnimi} ja {aeg} vana");
    }
}
