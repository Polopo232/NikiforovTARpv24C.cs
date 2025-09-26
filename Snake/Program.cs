using EsimeneTund.Snake;
using System.Text;
using System.Media;

namespace EsimeneTund;

internal class SnakeProgram
{
    static int extraLives = 0;
    static Point specialFood = null;
    static DateTime lastSpecialFoodTime = DateTime.Now;
    static DateTime lastBombTime = DateTime.Now;

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int score = 0;
        int fast = 100;
        List<Bomb> activeBombs = new List<Bomb>();
        int bombCount = 0;
        string name = "";
        bool game_over = false;

        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\snakeresourse\score.txt");
        string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\snakeresourse\1point.wav");
        string specialSoundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\snakeresourse\uvelichen-mar.wav");
        string gameOverSoundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\snakeresourse\game-over-mario.wav");

        GameChoose gameChoose = new GameChoose();
        gameChoose.ChooseMode();

        DrawScore drawScore = new DrawScore();

        Console.Clear();

        Walls walls = new Walls(80, 25);
        walls.Draw();

        DrawScore.DrawScoreBorder();
        DrawScore.UpdateScoreDisplay(score);
        DrawScore.UpdateLivesDisplay(extraLives);

        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;

        Point startPoint = new Point(4, 5, '■');
        Snake.Snake snake = new Snake.Snake(startPoint, 4, Direction.RIGHT);
        snake.Draw();

        FoodCreator foodcreator = new FoodCreator(80, 25, '$');
        SpecialFoodCreator specialFoodCreator = new SpecialFoodCreator(80, 25, '♥');

        Snake.Point food = foodcreator.CreateFood();
        food.Draw();

        while (true)
        {
            if (gameChoose.chosenMode == 4)
            {
                if (bombCount <= 20 && (DateTime.Now - lastBombTime).TotalSeconds >= 0.5)
                {
                    Bomb newBomb = new Bomb(80, 25, '☢');
                    activeBombs.Add(newBomb);
                    newBomb.Draw();
                    lastBombTime = DateTime.Now;
                    bombCount++;
                }
            }
            else
            {
                fast = 100;
            }

            if ((DateTime.Now - lastSpecialFoodTime).TotalSeconds >= 30 && specialFood == null)
            {
                if (gameChoose.chosenMode != 4)
                    specialFood = specialFoodCreator.CreateSpecialFood();
                specialFood?.Draw();
                lastSpecialFoodTime = DateTime.Now;
            }

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                gameChoose.HandleKeyInversion(snake, key);
            }

            bool bombHit = false;
            Bomb hitBomb = null;

            foreach (var currentBomb in activeBombs)
            {
                if (currentBomb.Position.IsHit(snake.Head))
                {
                    bombHit = true;
                    hitBomb = currentBomb;
                    break;
                }
            }

            if (bombHit || walls.IsHit(snake) || snake.IsHitTail())
            {
                if (bombHit)
                {
                    hitBomb.Clear();
                    activeBombs.Remove(hitBomb);
                }

                if (extraLives > 0)
                {
                    extraLives--;
                    DrawScore.UpdateLivesDisplay(extraLives);

                    snake.Clear();

                    startPoint = new Point(4, 5, '■');
                    var newsnake = new Snake.Snake(startPoint, snake.pList.Count, Direction.RIGHT);
                    snake = newsnake;
                    snake.Draw();
                    continue;
                }
                else
                {
                    Console.Clear();
                    gameChoose.WriteCentered($"Score: {score}");
                    gameChoose.WriteCentered("Liidrite nimekiri: ");
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
                            gameChoose.WriteCentered($"{i + 1}. {names[i]}: {scores[i]}");
                        }
                        gameChoose.WriteCentered("Sisesta nimi: ");
                        name = Console.ReadLine();
                    }
                    game_over = true;
                    break;
                }
            }

            if (snake.Eat(food))
            {
                if (File.Exists(soundPath))
                {
                    try
                    {
                        SoundPlayer player = new SoundPlayer(soundPath);
                        player.Play();
                    }
                    catch (Exception)
                    {

                    }
                }
                score++;
                DrawScore.UpdateScoreDisplay(score);
                gameChoose.IncreaseSpeed();
                food = foodcreator.CreateFood();
                food.Draw();
            }
            else if (specialFood != null && snake.Eat(specialFood))
            {
                if (File.Exists(specialSoundPath))
                {
                    try
                    {
                        SoundPlayer player = new SoundPlayer(specialSoundPath);
                        player.Play();
                    }
                    catch (Exception) { }
                }

                extraLives++;
                DrawScore.UpdateLivesDisplay(extraLives);
                specialFood = null;
            }
            else
            {
                snake.Move();
            }
            Thread.Sleep(fast);
        }

        if (game_over)
        {
            if (File.Exists(gameOverSoundPath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(gameOverSoundPath);
                    player.Play();
                }
                catch (Exception) { }
            }
            using (StreamWriter text = new StreamWriter(path, true))
            {
                if (score != 0) { text.WriteLine($"{name}: {score}"); }
            }
        }

        static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}