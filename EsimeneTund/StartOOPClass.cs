namespace EsimeneTund;

internal class StartOOPClass
{
    public static void Main(string[] args)
    {
        OOP.Inimene inimene1 = new OOP.Inimene();
        inimene1.Nimi = "Juku";
        inimene1.Vanus = 30;
        inimene1.Tervita();

        OOP.Inimene inimene2 = new OOP.Inimene("Kati", 20);

        OOP.Töötaja töötaja1 = new OOP.Töötaja();
        töötaja1.Nimi = "Mati";
        töötaja1.Vanus = 25;
        töötaja1.Ametikoht = "Arendaja";
        töötaja1.Tervita();
        töötaja1.Töötan();

        OOP.Palka palka1 = new OOP.Palka();

        palka1.Nimi = "Mari";
        palka1.Vanus = 28;
        palka1.Palk = 2000;
        palka1.Tervita();
        palka1.NäitaPalk();

    }

}
