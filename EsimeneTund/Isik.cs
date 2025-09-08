using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsimeneTund
{
    internal class Isik
    {
        public string eesNimi;
        public string perNimi = "Tundumatu";
        public int synniaasta = 2000;

        public Isik() { }
        public Isik(string eesNimi, string perNimi)
        {
            this.eesNimi = eesNimi;
            this.perNimi = perNimi;
        }
        public void printInfo()
        {
            Console.WriteLine($"Isiku nimi on {eesNimi} {perNimi}");
        }
    }
}
