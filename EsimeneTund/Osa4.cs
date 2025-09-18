namespace EsimeneTund;

internal class Osa4
{
    public static void KirjutaFail()
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt"); //@"..\..\..\Kuud.txt"
            StreamWriter text = new StreamWriter(path, true); // true = lisa lõppu
            Console.WriteLine("Sisesta mingi tekst: ");
            string lause = Console.ReadLine();
            text.WriteLine(lause);
            text.Close();
        }
        catch (Exception)
        {
            Console.WriteLine("Mingi viga failiga");
        }
    }
    public static void Faili_lugemine(string failinimi)
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, failinimi);
            StreamReader text = new StreamReader(path);
            string laused = text.ReadToEnd();
            text.Close();
            Console.WriteLine(laused);
        }
        catch (Exception)
        {
            Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
        }
    }
    public static List<string> Ridade_lugemine(string failinimi)
    {
        List<string> kuude_list = new List<string>();

        Console.WriteLine("Sisesta kuu nimi, mida otsida:");
        string otsitav = Console.ReadLine();

        if (kuude_list.Contains(otsitav))
            Console.WriteLine("Kuu " + otsitav + " on olemas.");
        else
            Console.WriteLine("Sellist kuud pole.");

        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");
            foreach (string rida in File.ReadAllLines(path))
            {
                kuude_list.Add(rida);
            }
            return kuude_list;
        }
        catch (Exception)
        {
            Console.WriteLine("Viga failiga!");
            return kuude_list;
        }
    }
}
