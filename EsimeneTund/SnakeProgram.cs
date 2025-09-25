using EsimeneTund.Snake;
using System.Formats.Asn1;
using System.Text;
namespace EsimeneTund;

internal class SnakeProgram
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int score = 0;
        int fast = 100;
        string name = "";
        bool game_over = false;

        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\score.txt");

        GameChoose gameChoose = new GameChoose();
        gameChoose.ChooseMode();

        Console.WriteLine("Sisesta nimi: ");
        name = Console.ReadLine();
        Console.Clear();


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
                gameChoose.HandleKeyInversion(snake, key);
            }

            if (walls.IsHit(snake) || snake.IsHitTail())
            {
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                Console.WriteLine($"Score: {score}");
                // Список лидеров
                Console.WriteLine("Liidrite nimekiri: ");
                if (File.Exists(path))
                {
                    string[] allLines = File.ReadAllLines(path);

                    List<string> names = new List<string>();
                    List<int> scores = new List<int>();

                    foreach (string line in allLines)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length >= 2)
                        {
                            if (int.TryParse(parts[1].Trim(), out int playerScore))
                            {
                                names.Add(parts[0].Trim());
                                scores.Add(playerScore);
                            }
                        }
                    }
                    for (int i = 0; i < scores.Count - 1; i++)
                    {
                        for (int j = i + 1; j < scores.Count; j++)
                        {
                            if (scores[i] < scores[j])
                            {
                                int tempScore = scores[i];
                                scores[i] = scores[j];
                                scores[j] = tempScore;

                                string tempName = names[i];
                                names[i] = names[j];
                                names[j] = tempName;
                            }
                        }
                    }
                    for (int i = 0; i < names.Count; i++)
                    {
                        Console.WriteLine($"{names[i]}: {scores[i]}");
                    }
                }
                game_over = true;
                break;
            }

            if (snake.Eat(food))
            {
                score += 1;
                gameChoose.IncreaseSpeed();
                food = foodcreator.CreateFood();
                food.Draw();
            }
            else
            {
                snake.Move();
            }
            Thread.Sleep(fast);
        }

        if (game_over) { 
            using (StreamWriter text = new StreamWriter(path, true))
            {
                text.WriteLine($"{name}: {score}");
            }
        }

        static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}
