using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsimeneTund
{
    internal class Class3
    {
        public static int[] GenereeriRuudud(int min, int max)
        {
            Random rnd = new Random();
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


    }
}
