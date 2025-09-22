using EsimeneTund.Snake;
using System.Drawing;

namespace EsimeneTund;

internal class SnakeProgram
{
    static void Main(string[] args)
    {

        int score = 0;

        Walls walls = new Walls(80, 25);
        walls.Draw();

        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;

        Snake.Point p = new Snake.Point(4, 5, '*');
        Snake.Snake snake = new Snake.Snake(p, 4, Direction.RIGHT);
        snake.Draw();

        FoodCreator foodcreator = new FoodCreator(80, 25, '$');
        Snake.Point food = foodcreator.CreateFood();
        food.Draw();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                snake.HandelKey(key);
            }

            if (walls.IsHit(snake) || snake.IsHitTail())
            {
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                Console.WriteLine($"Score: {score}");
                break;
            }

            if (snake.Eat(food))
            {
                food = foodcreator.CreateFood();
                food.Draw();
            }
            if (snake.Eat(food))
            {
                score += 1;
            }
            else
            {
                snake.Move();
            }

            Thread.Sleep(100);
        }


        static void Draw(Figure figure)
        {
            figure.Draw();
        }

    }
}
