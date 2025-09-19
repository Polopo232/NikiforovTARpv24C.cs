using EsimeneTund.Auto;

class Program
{
    static void Main(string[] args)
    {
        List<ISõiduk> sõidukid = new List<ISõiduk>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("-----Sõiduki tüüp-----");
            Console.WriteLine("1 - Auto\n2 - Jalgratas\n3 - Buss\n0 - Lõpp");
            int tüüp = int.Parse(Console.ReadLine());

            if (tüüp == 0)
            {
                break;
            }

            Console.Write("Vahemaa (km): ");
            string vahemaaSisend = Console.ReadLine().ToLower();
            double vahemaa;
            if (!double.TryParse(vahemaaSisend, out vahemaa))
            {
                Console.WriteLine("Viga! Sisesta number.");
                continue;
            }

            if (tüüp == 1)
            {
                Console.Write("Kütusekulu (l/100km): ");
                string kuluSisend = Console.ReadLine().ToLower();
                double kütusekulu;
                if (!double.TryParse(kuluSisend, out kütusekulu))
                {
                    Console.WriteLine("Viga! Sisesta number.");
                    continue;
                }
                sõidukid.Add(new Auto(kütusekulu, vahemaa));
            }
            else if (tüüp == 2)
            {
                sõidukid.Add(new Jalgratas(vahemaa));
            }
            else if (tüüp == 3)
            {
                Console.Write("Kütusekulu (l/100km): ");
                string kuluSisend = Console.ReadLine().ToLower();
                double kütusekulu;
                if (!double.TryParse(kuluSisend, out kütusekulu))
                {
                    Console.WriteLine("Viga! Sisesta number.");
                    continue;
                }
                Console.Write("Reisijate arv: ");
                string reisijadSisend = Console.ReadLine().ToLower();
                int reisijateArv;
                if (!int.TryParse(reisijadSisend, out reisijateArv))
                {
                    Console.WriteLine("Viga! Sisesta number.");
                    continue;
                }
                sõidukid.Add(new Buss(kütusekulu, vahemaa, reisijateArv));
            }
            else
            {
                Console.WriteLine("Vale tüüp! Vali auto, jalgratas või buss.");
            }
        }

        Console.WriteLine("Tulemused:");
        int number = 1;
        foreach (ISõiduk sõiduk in sõidukid)
        {
            string nimi = "Tundmatu";
            if (sõiduk is Auto)
                nimi = "Auto";
            else if (sõiduk is Jalgratas)
                nimi = "Jalgratas";
            else if (sõiduk is Buss)
                nimi = "Buss";
            Console.WriteLine();
            Console.WriteLine($"----{nimi}-----");
            Console.WriteLine($"Vahemaa: " + sõiduk.ArvutaVahemaa() + " km");
            Console.WriteLine($"Kulu: " + sõiduk.ArvutaKulu() + (nimi == "Jalgratas" ? " kcal" : " liitrit"));
            Console.WriteLine();
            number++;
        }
    }
}