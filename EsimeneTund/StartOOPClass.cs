using EsimeneTund.OOP;
using static EsimeneTund.Kujud;

namespace EsimeneTund;

internal class StartOOPClass
{
    public static void Main(string[] args)
    {



        //OOP.Inimene inimene1 = new OOP.Inimene();
        //inimene1.Nimi = "Juku";
        //inimene1.Vanus = 30;
        //inimene1.Tervita();

        //OOP.Inimene inimene2 = new OOP.Inimene("Kati", 20);

        //OOP.AbstracktClass.Kass loom1 = new OOP.AbstracktClass.Kass();
        //loom1.Nimi = "Murka";
        //loom1.TeeHääl();
        //loom1.Toug();

        //OOP.AbstracktClass.Koer loom2 = new OOP.AbstracktClass.Koer();
        //loom2.Nimi = "Kusti";
        //loom2.TeeHääl();
        //loom2.Toug();

        //Console.Clear();

        //OOP.Töötaja töötaja1 = new OOP.Töötaja();
        //töötaja1.Nimi = "Mati";
        //töötaja1.Vanus = 25;
        //töötaja1.Ametikoht = "Arendaja";
        //töötaja1.Tervita();
        //töötaja1.Töötan();
        //töötaja1.Tunnid = 160;
        //double palk = töötaja1.ArvutaPalk();
        //Console.WriteLine($"{töötaja1.Nimi} teenim kuus {palk} eurot");
        //Console.WriteLine($"Algne konto on {töötaja1.Konto.Saldo} eurot");
        //töötaja1.Konto.Saldo += 1000;
        //Console.WriteLine($"Pärast sissetulekut on konto {töötaja1.Konto.Saldo} eurot");
        //töötaja1.Konto.VõtaRaha(200);
        //Console.WriteLine($"Pärast väljamakset on konto {töötaja1.Konto.Saldo} eurot");
        //töötaja1.Konto.LisaRaha(900);
        //Console.WriteLine($"Pärast raha lisamist on konto {töötaja1.Konto.Saldo} eurot");

        List<IKujund> kujundid = new List<IKujund>();

        while (true)
        {
            Console.WriteLine("Vali kujund:\n1=Ruut\n2=Ring\n3=Kolmnurk\n0=Välju");
            Console.Write(": ");
            string valik = Console.ReadLine();

            if (valik == "0") break;

            switch (valik)
            {
                case "1":
                    Console.Write("Sisesta küljepikkus: ");
                    double külg = double.Parse(Console.ReadLine());
                    kujundid.Add(new Ruut(külg));
                    break;

                case "2":
                    Console.Write("Sisesta raadius: ");
                    double r = double.Parse(Console.ReadLine());
                    kujundid.Add(new Ring(r));
                    break;

                case "3":
                    Console.Write("Sisesta kolm külge (A B C): ");
                    string[] osad = Console.ReadLine().Split();
                    double a = double.Parse(osad[0]);
                    double b = double.Parse(osad[1]);
                    double c = double.Parse(osad[2]);
                    kujundid.Add(new Kolmnurk(a, b, c));
                    break;

                default:
                    Console.WriteLine("Tundmatu valik.");
                    break;
            }
        }

        Console.WriteLine("\n--- Kujundite tulemused ---");
        foreach (var kujund in kujundid)
        {
            Console.WriteLine($"Pindala: {kujund.ArvutaPindala():F2}, Ümbermõõt: {kujund.ArvutaÜmbermõõt():F2}");
        }





    }

}
