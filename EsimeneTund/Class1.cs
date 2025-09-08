using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EsimeneTund
{
    internal class Class1
    {
        public static void Main(string[] args) {
            Random rnd = new Random();
            Console.OutputEncoding = Encoding.UTF8;

            double[] arvud = Class3.Tekstist_arvud();
            var tulemus = Class3.AnalusArve(arvud);
            Console.WriteLine($"Summa = {tulemus.Item1:F2}, Keskmine = {tulemus.Item2:F2}, Korrutis = {tulemus.Item3:F2}");


            //Osa Massiivid, List, Kordused
            int j = 0;
            List<Isik> isikukod = new List<Isik>();
            j = 0;
            do
            {
                Console.WriteLine(j + 1);
                Isik isik = new Isik();
                Console.WriteLine("Eesnimi: ");
                isik.eesNimi = Console.ReadLine();
                isikukod.Add(isik);
                j++;
            }
            while (j < 10);
            isikukod.Sort((x, y) => x.eesNimi.CompareTo(y.eesNimi));
            Console.WriteLine("Kokku on", isikukod.Count(), " isikud");
            foreach (Isik isik in isikukod)
            {
                isik.printInfo();
            }

            List<string> nimed = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1}. Nimi: ");
                nimed.Add(Console.ReadLine());
            }
            foreach (string nimi in nimed)
            {
                Console.WriteLine(nimi);
            }
            int[] arvutid = new int[10];
            while (j < 10)
            {
                Console.WriteLine(j + 1);
                arvutid[j] = rnd.Next(1, 101);
                j++;
            }
            foreach (int arv in arvutid)
            {
                Console.WriteLine(arv);
            }
            j = 0;
            do
            {
                Console.WriteLine(j + 1);
                j++;
            }
            while (j < 10);


            ////Ulesanne 6

            //Console.WriteLine("Напиши свой рост");
            //float pikk_in = Console.ReadLine();
            //Console.WriteLine(Class2.pikk(pikk_in);

            ////Ulesanne 5

            //Console.WriteLine("Kirjuta temperatuur: ");
            //float temp = float.Parse(Console.ReadLine());

            //Console.WriteLine(Class2.temp(temp));

            ////Ulesanne 4

            //Console.WriteLine("Kirjuta hind: ");
            //try
            //{
            //    float hind = float.Parse(Console.ReadLine());
            //    float uue_hind = Class2.soodused(hind);
            //    Console.WriteLine($"Sinu hind sooduseta {uue_hind}");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            ////Ulesanne 3

            //Console.WriteLine("Pikk: ");
            //int a_pikk = rnd.Next(100, 300);
            //int b_pikk = rnd.Next(300, 450);
            //Console.WriteLine($"A = {a_pikk} ja B = {b_pikk}");

            //int S_pram = Class2.pram(a_pikk, b_pikk);

            //Console.WriteLine("Kas soovite uut remonti?");
            //string inimene = Console.ReadLine();

            //if (inimene.ToLower() == "jah")
            //{
            //    try
            //    {
            //        Console.WriteLine("Kui palju on ruutmeeter: ");
            //        string input = Console.ReadLine();
            //        int inimene1 = int.Parse(input);
            //        int ruut_hind = inimene1 * 50;
            //        Console.WriteLine($"Uue remont oli {ruut_hind} euro");
            //    }
            //    catch (Exception x)
            //    {
            //        Console.WriteLine(x);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Ok");
            //}


            ////Ulesanne 2
            //Console.WriteLine("Kirjuta nimi 1: ");
            //string nimi1 = Console.ReadLine();
            //Console.WriteLine("Kirjuta nimi 2: ");
            //string nimi2 = Console.ReadLine();

            //Console.WriteLine(Class2.pinginaabrid(nimi1, nimi2));

            ////Ulesanne 1
            //Console.WriteLine("Kes on sinu nimi?");
            //string nimi_vastus = Console.ReadLine();
            //if (nimi_vastus.ToLower() == "juku")
            //{
            //    try
            //    {
            //        Console.WriteLine("AEG kakoi?: ");
            //        int aeg = int.Parse(Console.ReadLine());
            //        Console.WriteLine(Class2.juuki_aeg(aeg));
            //    }
            //    catch (Exception x)
            //    {
            //        Console.WriteLine(x);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Sa ei ole Juku !!!");
            //}


            //2 osa

            //int Kuu_number = rnd.Next(1,12);
            //string nimetus = Class2.kuu_nimetus(Kuu_number);
            //Console.WriteLine($"Nr: {Kuu_number}-{nimetus}");

            //Console.WriteLine("Kas sa tahad dekodeerida arv -> Nimetusse");
            //string vastus = Console.ReadLine();
            //if (vastus.ToLower() != "jah")
            //{
            //    Console.WriteLine("Ei taha, siis ei taha");
            //}
            //else
            //{
            //    try
            //    {
            //        Console.WriteLine("Nr: ");
            //        Kuu_number = int.Parse(Console.ReadLine());
            //        Console.WriteLine(Class2.hooaeg(Kuu_number));
            //    }
            //    catch (Exception x)
            //    {
            //        Console.WriteLine(x);
            //    }

            //}

            //1 osa

            //Console.BackgroundColor = ConsoleColor.DarkMagenta;

            //Console.WriteLine("Tere Tulemast! Mis on sinu nimi ?");
            //string tekst = Console.ReadLine();
            //Console.WriteLine($"{tekst}, Rõõm naha");
            //int a = 1000;
            //char taht = 'A';
            //Console.WriteLine($"Esimene arv on {a}, Sisesta b = ...");
            //int b = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Summa a+b on {a+b}");
            //Console.WriteLine("Ujukommarv");
            //double r = double.Parse(Console.ReadLine());
            //Console.WriteLine($"Double on {r}");
            //float f = float.Parse(Console.ReadLine());
            //Console.WriteLine($"Float on {f}");
            //bool v = true;

            //a = rnd.Next(-100, 200);
            //Console.WriteLine(a);
            //float vastus = Class2.Kalulaator(f, b);
            //Console.WriteLine($"Korrutis on {vastus}");
        }
    }
}
