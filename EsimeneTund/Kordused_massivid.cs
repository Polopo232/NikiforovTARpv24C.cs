namespace EsimeneTund;

internal class Kordused_massivid
{
    private static Random rnd = new Random();
    public static int[] GenereeriRuudud(int min, int max)
    {
        int n = rnd.Next(min, max + 1);
        int m = rnd.Next(min, max + 1);

        int start = Math.Min(n, m);
        int end = Math.Max(n, m);

        int length = end - start + 1;
        int[] ruut = new int[length];

        for (int i = 0; i < length; i++)
        {
            int num = start + i;
            ruut[i] = num * num;
        }

        for (int i = 0; i < ruut.Length; i++)
        {
            int num = start + i;
            Console.WriteLine($"{num} → {ruut[i]}");
        }

        Console.WriteLine($"Сгенерированы числа {n} и {m}");

        return ruut;
    }
    public static double[] Tekstist_arvud()
    {
        Console.WriteLine("Sisesta arvud koma või tühikuga eraldatult: ");
        string sisend = Console.ReadLine();
        char[] eraldajad = new char[] { ' ', ',', ';' }; // Крутой массив разделителей

        string[] osad = sisend.Split(eraldajad, StringSplitOptions.RemoveEmptyEntries);
        double[] arvud = new double[osad.Length];
        for (int i = 0; i < osad.Length; i++)
        {
            arvud[i] = Convert.ToDouble(osad[i]);
        }
        return arvud;
    }
    public static Tuple<double, double, double> AnalusArve(double[] arvud)
    {
        double summa = arvud.Sum();
        double keskmine = arvud.Average();
        double korrutis = 1;
        foreach (double arv in arvud)
        {
            korrutis *= arv;
        }
        return Tuple.Create(summa, keskmine, korrutis);
    }
    public static void KuniMärksõnani(string marksona, string fraas)
    {
        List<string> inim_vastus = new List<string>();

        string inimene_vastu = "";

        do
        {
            Console.WriteLine(fraas);
            inimene_vastu = Console.ReadLine();

            inim_vastus.Add(inimene_vastu);

            if (marksona == inimene_vastu)
            {
                Console.WriteLine("Kõik korras");
                foreach (var item in inim_vastus)
                {
                    Console.WriteLine(item);
                }
            }
        }
        while (marksona.ToLower() != inimene_vastu.ToLower()) ;
        
        
    }
    public static void ArvaArv()
    {
        int ran_num = rnd.Next(1, 100);


        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Sinu katse num {i}: ");
            int prov = int.Parse(Console.ReadLine());

            if (prov == ran_num)
            {
                Console.WriteLine("See on õige");
            }
            else if (prov < ran_num)
            {
                Console.WriteLine("Proovi suuremat numbrit");
            }
            else
            {
                Console.WriteLine("Proovi väiksemat numbrit");
            }
        }

    }
    // Ulesanne 6
    public static void SuurimNeljarv(double[] arvud)
    {
        // 1573 -> 7531
        Array.Sort(arvud);
        Console.WriteLine($"Suurim neljarv on: {arvud[3]}{arvud[2]}{arvud[1]}{arvud[0]}");
    }
    // Ulesanne 7
    public static void GenereeriKorrutustabel(int ridadeArv, int veergudeArv)
    {
        int[,] tabel = new int[ridadeArv + 1, veergudeArv + 1];
        for (int i = 1; i <= ridadeArv; i++)
        {
            for (int j = 1; j <= veergudeArv; j++)
            {
                tabel[i, j] = i * j;
                Console.Write($"{tabel[i, j].ToString().PadLeft(4)}");
            }
            Console.WriteLine();
        }
    }

    public static void Opelased(string[] opelased)
    {
        foreach (var item in opelased)
        {
            Console.Write(item + "  ");
        }

        opelased[2] = "Kati";
        opelased[5] = "Mati";
        Console.WriteLine();
        foreach (var item in opelased)
        {
            Console.Write(item + "  ");
        }


        int j = 0;
        Console.WriteLine();
        while (j < opelased.Length)
        {
            string nimi = opelased[j];
            if (nimi[0] == 'A')
            {
                Console.WriteLine($"Tere! {nimi}");
            }
            j++;
        }

        for (int i = 0; i < opelased.Length; i++)
        {
            Console.WriteLine(opelased[i] +" "+ i);
        }
    }

}
