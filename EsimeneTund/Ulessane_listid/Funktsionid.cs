namespace EsimeneTund.Ulessane_listid;

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

    }\


}
