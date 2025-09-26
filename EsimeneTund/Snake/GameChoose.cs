namespace EsimeneTund.Snake;

internal class GameChoose
{
    public int speed = 100;
    public int chosenMode = 1;
    public bool inversion = false;
    public int input;
    public void ChooseMode()
    {
        Console.Clear();
        Console.WriteLine("Vali mängurežiim:");
        Console.WriteLine("1. Tavaline");
        Console.WriteLine("2. SpeedUP");
        Console.WriteLine("3. Inversioon");

        while (true)
        {
            try
            {

                input = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                Console.WriteLine("Vali mängurežiim:");
                Console.WriteLine("1. Tavaline");
                Console.WriteLine("2. SpeedUP");
                Console.WriteLine("3. Inversioon");
            }
        }

        

        if (input == 1)
        {
            chosenMode = 1;
            speed = 100;
            inversion = false;
            Console.WriteLine("Valisid tavalse režiimi");
        }
        else if (input == 2)
        {
            chosenMode = 2;
            speed = 100;
            inversion = false;
            Console.WriteLine("Valisid SpeedUP režiimi");
        }
        else if (input == 3)
        {
            chosenMode = 3;
            speed = 100;
            inversion = true;
            Console.WriteLine("Valisid inversiooni režiimi");
        }
        else
        {
            Console.WriteLine("Vale valik, läheb tavaline režiim");
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
