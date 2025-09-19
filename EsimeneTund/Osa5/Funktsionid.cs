using static EsimeneTund.osa5.Inimene;

namespace EsimeneTund.osa5;

internal class Funktsionid
{
    public static Inimene DataAsk()
    {
        Console.WriteLine("Kirjuta sinu adndmed: ");

        Console.Write("Nimi: ");
        string nimi = Console.ReadLine();

        Console.Write("Vanus: ");
        int aeg = int.Parse(Console.ReadLine());

        Console.Write("Sugu: ");
        string sugu = Console.ReadLine();

        Console.Write("Pikkus (cm): ");
        float pikkus = float.Parse(Console.ReadLine());

        Console.Write("Kaal (kg): ");
        float kaal = float.Parse(Console.ReadLine());

        Console.Write("Aktiivsustase (1-5): ");
        int aktiivsustase = int.Parse(Console.ReadLine());

        Inimene inimene = new Inimene(nimi, aeg, sugu, pikkus, kaal, aktiivsustase);
        return inimene;    
    }

    public static void Matem (Inimene i, List<Toode> tooted)
    {
        double bmr = 0.0;

        if (i.sugu == "m" || i.sugu == "M")
        {
            bmr = 88.362 + (13.397 * i.kaal) + (4.799 * i.pikkus) - (5.677 * i.aeg);
        }
        else if (
            i.sugu == "n" || i.sugu == "N")
        {
            bmr = 447.593 + (9.247 * i.kaal) + (3.098 * i.pikkus) - (4.330 * i.aeg);
        }
        else
        {
            Console.WriteLine("Vale sugu sisestatud.");
            return;
        }

        double activityMultiplier = i.aktiivsustase switch
        {
            1 => 1.2,
            2 => 1.375,
            3 => 1.55,
            4 => 1.725,
            5 => 1.9,
            _ => 1.0
        };
        double tanavkal = bmr * activityMultiplier;

        Console.WriteLine($"Sinu BMR on {bmr:F2} kalorit päevas.");

        foreach (var item in tooted)
        {
            double gram = (tanavkal / item  .kalorid100g) * 100;
            Console.WriteLine($"Sinu päevane {item.nimi} kogus on {gram:F2} g.");

        }
    }

    public static void MaajaPea()
    {
        Dictionary<string, string> maakonnad = new Dictionary<string, string>();

        maakonnad["Harju"] = "Tallinn";
        maakonnad["Tartu"] = "Tartu";
        maakonnad["Pärnu"] = "Pärnu";

        while (true)
        {
            Console.WriteLine("Mida soovite teha?");
            Console.WriteLine("1 - Otsi maakonda pealinna järgi");
            Console.WriteLine("2 - Otsi pealinna maakonna järgi");
            Console.WriteLine("3 - Lisa uus maakond ja pealinn");
            Console.WriteLine("4 - Mängurežiim");
            Console.WriteLine("0 - Välju");
            Console.Write("Teie valik: ");
            string valik = Console.ReadLine();

            if (valik == "0")
            {
                break;
            }
            else if (valik == "1")
            {
                Console.Write("Sisesta pealinna nimi: ");
                string pealinn = Console.ReadLine();

                bool leitud = false;
                foreach (var paar in maakonnad)
                {
                    if (paar.Value.ToLower() == pealinn.ToLower())
                    {
                        Console.WriteLine("Pealinn " + pealinn + " asub maakonnas " + paar.Key);
                        leitud = true;
                        break;
                    }
                }
                if (!leitud)
                {
                    Console.WriteLine("Andmeid ei leitud. Kas soovid lisada? (jah/ei)");
                    string vastus = Console.ReadLine();
                    if (vastus.ToLower() == "jah")
                    {
                        Console.Write("Sisesta maakond pealinna " + pealinn + " jaoks: ");
                        string uusMaakond = Console.ReadLine();
                        maakonnad[uusMaakond] = pealinn;
                        Console.WriteLine("Lisatud!");
                    }
                }
            }
            else if (valik == "2")
            {
                Console.Write("Sisesta maakonna nimi: ");
                string maakond = Console.ReadLine();

                if (maakonnad.ContainsKey(maakond))
                {
                    Console.WriteLine("Maakonna " + maakond + " pealinn on " + maakonnad[maakond]);
                }
                else
                {
                    Console.WriteLine("Andmeid ei leitud. Kas soovid lisada? (jah/ei)");
                    string vastus = Console.ReadLine();
                    if (vastus.ToLower() == "jah")
                    {
                        Console.Write("Sisesta pealinn maakonnale " + maakond + ": ");
                        string uusPealinn = Console.ReadLine();
                        maakonnad[maakond] = uusPealinn;
                        Console.WriteLine("Lisatud!");
                    }
                }
            }
            else if (valik == "3")
            {
                Console.Write("Sisesta maakond: ");
                string uusMaakond = Console.ReadLine();
                Console.Write("Sisesta pealinn: ");
                string uusPealinn = Console.ReadLine();
                maakonnad[uusMaakond] = uusPealinn;
                Console.WriteLine("Paar lisatud.");
            }
            else if (valik == "4")
            {
                Random rnd = new Random();
                int kokku = 0;
                int õiged = 0;

                List<string> maakondadeNimed = new List<string>(maakonnad.Keys);
                List<string> pealinnadeNimed = new List<string>(maakonnad.Values);

                for (int i = 0; i < 5; i++)
                {
                    kokku++;
                    int valikMäng = rnd.Next(0, 2);

                    if (valikMäng == 0)
                    {
                        int index = rnd.Next(maakondadeNimed.Count);
                        string kysitavMaakond = maakondadeNimed[index];
                        string õigeVastus = maakonnad[kysitavMaakond];

                        Console.Write("Mis on maakonna " + kysitavMaakond + " pealinn? ");
                        string vastus = Console.ReadLine();

                        if (vastus.ToLower() == õigeVastus.ToLower())
                        {
                            Console.WriteLine("Õige!");
                            õiged++;
                        }
                        else
                        {
                            Console.WriteLine("Vale. Õige vastus on: " + õigeVastus);
                        }
                    }
                    else
                    {
                        int index = rnd.Next(pealinnadeNimed.Count);
                        string kysitavPealinn = pealinnadeNimed[index];
                        string õigeMaakond = "";
                        foreach (var paar in maakonnad)
                        {
                            if (paar.Value == kysitavPealinn)
                            {
                                õigeMaakond = paar.Key;
                                break;
                            }
                        }

                        Console.Write("Millise maakonnaga kuulub pealinn " + kysitavPealinn + "? ");
                        string vastus = Console.ReadLine();

                        if (vastus.ToLower() == õigeMaakond.ToLower())
                        {
                            Console.WriteLine("Õige!");
                            õiged++;
                        }
                        else
                        {
                            Console.WriteLine("Vale. Õige vastus on: " + õigeMaakond);
                        }
                    }
                }

                double protsent = (double)õiged / kokku * 100;
                Console.WriteLine("Said õigesti " + õiged + " küsimust " + kokku + "st (" + protsent.ToString("F2") + "%).");
            }
            else
            {
                Console.WriteLine("Vale valik, proovi uuesti.");
            }

            Console.WriteLine();
        }
    }

    public static void Filmid() {
        List<Film> filmid = new List<Film>();

        filmid.Add(new Film("Matrix", 1999, "Ulme"));
        filmid.Add(new Film("Titanic", 1997, "Draama"));
        filmid.Add(new Film("Inception", 2010, "Ulme"));
        filmid.Add(new Film("The Godfather", 1972, "Krimi"));
        filmid.Add(new Film("Interstellar", 2014, "Ulme"));
        Console.WriteLine("Ulme filmid:");

                List<Film> ulmeFilmid = LeiaFilmidZanriJargi(filmid, "Ulme");
                foreach (Film f in ulmeFilmid)
                {
                    Console.WriteLine(f.pealkiri + " (" + f.aasta + ")");
                }

                // Leia uusim film
                Film uusim = LeiaUusimFilm(filmid);
                Console.WriteLine("\nUusim film on: " + uusim.pealkiri + " (" + uusim.aasta + ")");

                // Grupeeri filmid žanri järgi
                Dictionary<string, List<Film>> grupeeritud = GrupeeriFilmidZanriJargi(filmid);
            Console.WriteLine("\nFilmid žanri järgi:");
                foreach (var paar in grupeeritud)
                {
                    Console.WriteLine("Žanr: " + paar.Key);
                    foreach (Film f in paar.Value)
                    {
                        Console.WriteLine("  - " + f.pealkiri + " (" + f.aasta + ")");
                    }
                }
            }

            static List<Film> LeiaFilmidZanriJargi(List<Film> filmid, string zanr)
            {
            List<Film> tulemus = new List<Film>();

            foreach (Film film in filmid)
            {
                if (film.zanr.ToLower() == zanr.ToLower())
                {
                    tulemus.Add(film);
                }
            }

            return tulemus;
            }

            static Film LeiaUusimFilm(List<Film> filmid)
            {
            Film uusim = filmid[0];

            foreach (Film film in filmid)
            {
                if (film.aasta > uusim.aasta)
                {
                    uusim = film;
                }
            }

            return uusim;
            }

            static Dictionary<string, List<Film>> GrupeeriFilmidZanriJargi(List<Film> filmid)
            {
            Dictionary<string, List<Film>> grupeeritud = new Dictionary<string, List<Film>>();

            foreach (Film film in filmid)
            {
                if (!grupeeritud.ContainsKey(film.zanr))
                {
                    grupeeritud[film.zanr] = new List<Film>();
                }
                grupeeritud[film.zanr].Add(film);
            }

            return grupeeritud;
            }

    public static void OpilasedJaHinnete()
    {
        Õpilane opilane1 = new Õpilane();
        opilane1.Nimi = "Anna";
        opilane1.Hinded = new List<int> { 4, 5, 3, 4 };

        Õpilane opilane2 = new Õpilane();
        opilane2.Nimi = "Mati";
        opilane2.Hinded = new List<int> { 3, 3, 4, 5, 2 };

        Õpilane opilane3 = new Õpilane();
        opilane3.Nimi = "Kati";
        opilane3.Hinded = new List<int> { 5, 5, 4 };

        List<Õpilane> opilased = new List<Õpilane> { opilane1, opilane2, opilane3 };

        double parimKeskmine = 0;
        string parimNimi = "";

        foreach (Õpilane opilane in opilased)
        {
            double summa = 0;
            foreach (int hinne in opilane.Hinded)
            {
                summa = summa + hinne;
            }
            double keskmine = summa / opilane.Hinded.Count;

            Console.WriteLine(opilane.Nimi + " keskmine hinne: " + keskmine);

            if (keskmine > parimKeskmine)
            {
                parimKeskmine = keskmine;
                parimNimi = opilane.Nimi;
            }
        }

        Console.WriteLine("Parim keskmine on " + parimNimi + "-l: " + parimKeskmine);

        Console.WriteLine("\nSorteeritud keskmised (kahanevalt):");
        List<double> keskmised = new List<double>();
        List<string> nimed = new List<string>();

        foreach (Õpilane opilane in opilased)
        {
            double summa = 0;
            foreach (int hinne in opilane.Hinded)
            {
                summa = summa + hinne;
            }
            keskmised.Add(summa / opilane.Hinded.Count);
            nimed.Add(opilane.Nimi);
        }
        for (int i = 0; i < keskmised.Count; i++)
        {
            for (int j = i + 1; j < keskmised.Count; j++)
            {
                if (keskmised[i] < keskmised[j])
                {
                    double temp = keskmised[i];
                    keskmised[i] = keskmised[j];
                    keskmised[j] = temp;

                    string tempNimi = nimed[i];
                    nimed[i] = nimed[j];
                    nimed[j] = tempNimi;
                }
            }
        }
        for (int i = 0; i < keskmised.Count; i++)
        {
            Console.WriteLine(nimed[i] + ": " + keskmised[i]);
        }
    }
}
