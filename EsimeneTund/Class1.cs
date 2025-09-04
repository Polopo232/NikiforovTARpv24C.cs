using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EsimeneTund
{
    internal class Class1
    {
        public static void Main(string[] args) {

        //Console.BackgroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("Tere Tulemast! Mis on sinu nimi ?");
            string tekst = Console.ReadLine();
            Console.WriteLine($"{tekst}, Rõõm naha");
            int a = 1000;
            char taht = 'A';
            Console.WriteLine($"Esimene arv on {a}, Sisesta b = ...");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Summa a+b on {a+b}");
            Console.WriteLine("Ujukommarv");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine($"Double on {r}");
            float f = float.Parse(Console.ReadLine());
            Console.WriteLine($"Float on {f}");
            bool v = true;

            Random rnd = new Random();
            a = rnd.Next(-100, 200);
            Console.WriteLine(a);
            float vastus = Class2.Kalulaator(f, b);
            Console.WriteLine($"Korrutis on {vastus}");
        }

    }
}
