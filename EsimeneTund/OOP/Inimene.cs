namespace EsimeneTund.OOP;

internal class Inimene
{
    public string Nimi;
    public int Vanus;

    public Inimene() { }
    public Inimene(string nimi, int vanus)
    {
        Nimi = nimi;
        Vanus = vanus;
    }   
        public void Tervita()
        {
            Console.WriteLine("Tere! Mina olen " + Nimi);
        }
}
