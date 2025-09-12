namespace EsimeneTund;

internal class Inimene1
{
    public string eesnimi;
    public int aeg;
    public Inimene1() { }

    public Inimene1(string eesnimi, int aeg)
    {
        this.eesnimi = eesnimi;
        this.aeg = aeg;
    }
    public void printInfo()
    {
        Console.WriteLine($"Inimene nimi on {eesnimi} ja {aeg} vana");
    }
}