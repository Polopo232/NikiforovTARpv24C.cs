using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EsimeneTund
{
    internal class Class2
    {
        public static float Kalulaator(float arv1, float arv2)
        {
            float k = arv1 * arv2;
            return k;

        }
        public static string kuu_nimetus(int kuu_nr)
        {
            string kuu = "";
            switch (kuu_nr)
            {
                case 1:
                    kuu = "Jaanuar"; break;
                case 2:
                    kuu = "Veebruar"; break;
                case 3:
                    kuu = "Marts"; break;
                case 4:
                    kuu = "Aprill"; break;
                case 5:
                    kuu = "Mai"; break;
                case 6:
                    kuu = "Juuni"; break;
                case 7:
                    kuu = "Juuli"; break;
                case 8:
                    kuu = "August"; break;
                case 9:
                    kuu = "September"; break;
                case 10:
                    kuu = "Oktoober"; break;
                case 11:
                    kuu = "November"; break;
                case 12:
                    kuu = "Detsember"; break;
                default:
                    kuu = "???";
                    break;

            }
            return kuu;
        }
        public static string hooaeg(int kuu_nr)
        {
            string hoo = "";
            if (kuu_nr == 1 || kuu_nr == 2 || kuu_nr == 12)
            {
                hoo = "Talv";
            }
            else if (kuu_nr > 2 && kuu_nr < 6)
            {
                hoo = "Kevad";
            }
            else if (kuu_nr > 5 && kuu_nr < 9)
            {
                hoo = "Suvi";
            }
            else if (kuu_nr > 8 && kuu_nr < 12)
            {
                hoo = "Sügis";
            }
            else
            {
                hoo = "???";
            }
                return hoo;
        }
        public static string juuki_aeg(int juuki_nr)
        {
            string hind = "";

            if (juuki_nr <= 6)
            {
                hind = "Tasuta";
            }
            else if (juuki_nr >= 7 && juuki_nr <= 13)
            {
                hind = "Lapse piletit";
            }
            else if (juuki_nr >= 14 && juuki_nr < 65)
            {
                hind = "Täispiletit";
            }
            else if (juuki_nr >= 65)
            {
                hind = "Soodupiletit";
            }
            else
            {
                hind = "Viga andmetega";
            }

            return hind;
        }
        public static string pinginaabrid(string nimi1, string nimi2)
        {
            string result = "";

            if ((nimi1 == "Artjom" && nimi2 == "Roma") || (nimi1 == "Roma" && nimi2 == "Artjom") ||
                (nimi1 == "Mark" && nimi2 == "Marek") || (nimi1 == "Maker" && nimi2 == "Mark") ||
                (nimi1 == "Ilja" && nimi2 == "Martin") || (nimi1 == "Martin" && nimi2 == "Ilja") ||
                (nimi1 == "Nikita" && nimi2 == "Eldar") || (nimi1 == "Eldar" && nimi2 == "Nikita") ||
                (nimi1 == "Maks" && nimi2 == "Hussein") || (nimi1 == "Hussein" && nimi2 == "Maks"))
            {
                result = "Nad on pinginaabrid";
            }
            else
            {
                result = "Nad ei ole pinginaabrid";
            }
            return result;
        }
        public static int pram(int a, int b)
        {
            int S_pram = 2 * a + 2 * b;
            return S_pram;
        }
        public static float soodused(float a)
        {
            float uus_hind = a / 0.7f;
            return uus_hind;
        }
        public static string temp(float tempera)
        {
            if (tempera < 18)
            {
                return "See on talvel kõrge toatemperatuur";
            }
            else if (tempera > 18)
            {
                return "See on talvel väike toatemperatuur";
            }
            else
            {
                return "Toatemperatuur on ideaalne";
            }
                
        }
        public static string pikk(float pikk_inim)
        {
            if (pikk_inim >= 160)
            {
                return "Sa oled lühike, mees.";
            }
            else if (pikk_inim <= 180)
            {
                return "Чувак ты среднего роста";
            }
            else if (pikk_inim >= 210) {
                return "Чувак ты очень высокий";
            }
            else {
                return "Чувак ты очень высокий";
            }
        }
    }
}
