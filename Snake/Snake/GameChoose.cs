namespace EsimeneTund.Snake;

internal class GameChoose
{
    public int speed = 100;
    public int chosenMode = 1;
    public bool inversion = false;
    public int input;

    public void WriteCentered(string text)
    {
        try
        {
            int consoleWidth = Math.Max(Console.WindowWidth, text.Length + 2);
            int padding = (consoleWidth - text.Length) / 2;
            Console.WriteLine(text.PadLeft(padding + text.Length));
        }
        catch (Exception)
        {
            Console.WriteLine(text);
        }
    }

    public void ChooseMode()
    {
        Console.Clear();
        WriteCentered("Vali mängurežiim:");
        WriteCentered("1. Tavaline");
        WriteCentered("2. SpeedUP");
        WriteCentered("3. Inversioon");
        WriteCentered("4. Expert");

        while (true)
        {
            try
            {

                input = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception e)
            {
                Console.Clear();

                WriteCentered(e.Message);

                WriteCentered("Vali mängurežiim:");
                WriteCentered("1. Tavaline");
                WriteCentered("2. SpeedUP");
                WriteCentered("3. Inversioon");
                WriteCentered("4. Expert");
            }
        }

        

        if (input == 1)
        {
            chosenMode = 1;
            speed = 100;
            inversion = false;
            WriteCentered("Valisid tavalse režiimi");
        }
        else if (input == 2)
        {
            chosenMode = 2;
            speed = 100;
            inversion = false;
            WriteCentered("Valisid SpeedUP režiimi");
        }
        else if (input == 3)
        {
            chosenMode = 3;
            speed = 100;
            inversion = true;
            WriteCentered("Valisid inversiooni režiimi");
        }
        else if (input == 4)
        {
            chosenMode = 4;
            speed = 80;
            inversion = false;
            WriteCentered("Valisid Expert režiimi");
        }
        else
        {
            WriteCentered("Vale valik, läheb tavaline režiim");
            chosenMode = 1;
            speed = 100;
            inversion = false;
        }
    }
    public void HandleKeyInversion(Snake snake, ConsoleKey key)
    {
        if (inversion)
        {
            if (key == ConsoleKey.LeftArrow)
                snake.HandelKey(ConsoleKey.RightArrow);
            else if (key == ConsoleKey.RightArrow)
                snake.HandelKey(ConsoleKey.LeftArrow);
            else if (key == ConsoleKey.UpArrow)
                snake.HandelKey(ConsoleKey.DownArrow);
            else if (key == ConsoleKey.DownArrow)
                snake.HandelKey(ConsoleKey.UpArrow);
            else
                snake.HandelKey(key);
        }
        else
        {
            snake.HandelKey(key);
        }
    }

    public void IncreaseSpeed()
    {
        if (chosenMode == 2)
        {
            if (speed > 20)
            {
                speed -= 5;
            }
        }
    }
}
