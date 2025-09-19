namespace EsimeneTund.OOP;

internal class Inimene
{
    public string Nimi;
    public int Vanus;
    public Pank Konto{ get; set; }

    public Inimene() {
        Konto = new Pank();
    }
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
