namespace EsimeneTund.OOP
{
    class Töötaja : OOP.Inimene
        {
            public string Ametikoht;

            public void Töötan()
            {
                Console.WriteLine($"{Nimi} töötab ametikohal {Ametikoht}.");
            }
        }
}
