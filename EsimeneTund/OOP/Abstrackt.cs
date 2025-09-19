namespace EsimeneTund.OOP
{
    internal class AbstracktClass
    {
        public abstract class Loom
        {
            public string Nimi;
            public abstract void TeeHääl();
            public abstract void Toug();

            public Loom() { }

            public Loom(string nimi)
            {
                Nimi = nimi;
            }
        }

        public class Koer : Loom
        {
            public override void TeeHääl()
            {
                Console.WriteLine("Auh-auh!");
            }

            public override void Toug()
            {
                Console.WriteLine("Mops");
            }
        }

        public class Kass : Loom
        {
            public override void TeeHääl()
            {
                Console.WriteLine("Miau-miau!");
            }

            public override void Toug()
            {
                Console.WriteLine("Bengali");
            }
        }
    }
}