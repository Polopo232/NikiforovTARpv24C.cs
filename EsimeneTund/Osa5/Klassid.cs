namespace EsimeneTund.osa5;

internal class Toode
{
    public string nimi = "";
    public float kalorid100g = 0.0f;
    public Toode() { }
    public Toode(string nimi, float kalorid100g)
    {
        this.nimi = nimi;
        this.kalorid100g = kalorid100g;
    }
    public void printInfo()
    {
        Console.WriteLine($"Nimi: {nimi}, Kalorid 100g: {kalorid100g}");
    }
}

internal class Inimene
{
    public string nimi = "";
    public int aeg = 0;
    public string sugu = "";
    public float pikkus = 0.0f;
    public float kaal = 0.0f;
    public int aktiivsustase = 0;

    public Inimene() { }
    public Inimene(string nimi, int aeg, string sugu, float pikkus, float kaal, int aktiivsustase)
    {
        this.nimi = nimi;
        this.aeg = aeg;
        this.sugu = sugu;
        this.pikkus = pikkus;
        this.kaal = kaal;
        this.aktiivsustase = aktiivsustase;
    }

    public void printInfo()
    {
        Console.WriteLine($"Nimi: {nimi}, Aeg: {aeg}, Sugu: {sugu}, Pikkus: {pikkus}, Kaal: {kaal}, Aktiivsustase: {aktiivsustase}");
    }
    internal class Film
    {
        public string pealkiri = "";
        public int aasta = 0;
        public string zanr = "";

        public Film() { }

        public Film(string pealkiri, int aasta, string zanr)
        {
            this.pealkiri = pealkiri;
            this.aasta = aasta;
            this.zanr = zanr;
        }
    }
    internal class Õpilane
    {
        public string Nimi;
        public List<int> Hinded = new List<int>();

        public Õpilane(string nimi)
        {
            Nimi = nimi;
        }

        public Õpilane(string nimi, List<int> hinded)
        {
            Nimi = nimi;
            Hinded = hinded;
        }
        public Õpilane()
        {
            Nimi = "";
            Hinded = new List<int>();
        }
    }




}
