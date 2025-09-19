namespace EsimeneTund.OOP
{
    class Töötaja : OOP.Inimene
    {
        public string Ametikoht;
        public double Tunnitasu = 15.5;
        public int Tunnid { get; set; }

        public void Töötan() {
            {
                Console.WriteLine($"{Nimi} töötab ametikohal {Ametikoht}.");
            }
        }

        public double ArvutaPalk()
        {
            return Tunnitasu * Tunnid;
        }
    }
}
