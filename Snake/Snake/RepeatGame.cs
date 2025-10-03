using System;

namespace EsimeneTund
{
    internal class RepeatGame
    {
        public bool Repeat()
        {
            Console.WriteLine("Kas soovite mängu uuesti alustada? (Y/N)");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    return true;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    return false;
                }
            }
        }
    }
}
