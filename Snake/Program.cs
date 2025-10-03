using EsimeneTund.Snake;
using Snake.Snake;
using System.Diagnostics;
using System.Media;
using System.Numerics;
using System.Text;

namespace EsimeneTund;

internal class SnakeProgram
{
    static int extraLives = 0; // Lisalives ehk elud, mida saab juurde koguda
    static Point specialFood = null; // Eriline toit, mis ilmub harva
    static DateTime lastSpecialFoodTime = DateTime.Now; // Viimane kord, kui eriline toit ilmus
    static DateTime lastBombTime = DateTime.Now; // Viimane kord, kui pomm ilmus

    static void Main(string[] args)
    {
        // Määrame konsooli kodeeringu UTF-8 peale, et erimärgid õigesti kuvatakse
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        SoundPlay soundPlay = new SoundPlay(); // Heliefektide mängija

        GameOverShow gameOverShow = new GameOverShow(); // Mängu lõpu ekraani kuvaja

        RepeatGame repeatGame = new RepeatGame(); // Mängu kordamise haldur

        GameChoose gameChoose = new GameChoose(); // Mängurežiimi valija

        do
        {
            int score = 0; // Mängija punktisumma
            int fast = 100; // Mängu kiirus ehk viivitus ms
            List<Bomb> activeBombs = new List<Bomb>(); // Aktiivsed pommid mängus
            int bombCount = 0; // Pommi koguarv
            string name = ""; // Mängija nimi
            bool game_over = false; // Kas mäng on lõppenud?

            // Faili- ja heliradade seadistused
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\snakeresourse\score.txt");
            string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\snakeresourse\1point.wav");
            string specialSoundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\snakeresourse\uvelichen-mar.wav");
            string gameOverSoundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\snakeresourse\game-over-mario.wav");

            gameChoose.ChooseMode(); // Kasutaja valib mängurežiimi

            DrawScore drawScore = new DrawScore(); // Punktisumma joonistaja

            Console.Clear(); // Tühjendame konsooli

            Walls walls = new Walls(80, 25); // Loome mängu seinad
            walls.Draw(); // Joonistame seinad

            DrawScore.DrawScoreBorder(); // Joonistame punktisumma raamid
            DrawScore.UpdateScoreDisplay(score); // Kuvame punktisumma
            DrawScore.UpdateLivesDisplay(extraLives); // Kuvame elud

            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false; // Peidame kursor

            Point startPoint = new Point(4, 5, '■'); // Madu alguspunkt
            Snake.Snake snake = new Snake.Snake(startPoint, 4, Direction.RIGHT); // Loome madu
            snake.Draw(); // Joonistame madu

            FoodCreator foodcreator = new FoodCreator(80, 25, '$'); // Toiduloome objekt
            SpecialFoodCreator specialFoodCreator = new SpecialFoodCreator(80, 25, '♥'); // Erilise toidu looja

            Snake.Point food = foodcreator.CreateFood(); // Loome tavalise toidu
            food.Draw(); // Joonistame toidu

            void OpenImage(string imagePath)
            {
                // Avab pildi failisüsteemist, nt plahvatuse pilt
                Process.Start(new ProcessStartInfo(imagePath) { UseShellExecute = true });
            }

            while (true)
            {
                // Kui valitud on pommide režiim (režiim 4)
                if (gameChoose.chosenMode == 4)
                {
                    // Loome pommid kuni 20, pool sekundit intervalliga
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
                    fast = 100; // Muudes režiimides standardkiirus
                }

                // Iga 30 sekundi tagant ilmub eriline toit, kui seda veel pole
                if ((DateTime.Now - lastSpecialFoodTime).TotalSeconds >= 30 && specialFood == null)
                {
                    if (gameChoose.chosenMode != 4)
                        specialFood = specialFoodCreator.CreateSpecialFood();
                    specialFood?.Draw();
                    lastSpecialFoodTime = DateTime.Now;
                }

                // Kui kasutaja vajutab klahvi
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    gameChoose.HandleKeyInversion(snake, key); // Käitleme klahvivajutust (ka pööramist)
                }

                bool bombHit = false; // Kas madu tabas pommi?
                Bomb hitBomb = null; // Mis pomm tabati?

                // Kontrollime, kas madu pea tabas pommi
                foreach (var currentBomb in activeBombs)
                {
                    if (currentBomb.Position.IsHit(snake.Head))
                    {
                        bombHit = true;
                        hitBomb = currentBomb;
                        OpenImage(@"..\..\..\snakeresourse\explode.png"); // Näitame plahvatuse pilti
                        break;
                    }
                }

                // Kui madu tabas pommi, seina või saba
                if (bombHit || walls.IsHit(snake) || snake.IsHitTail())
                {
                    if (bombHit)
                    {
                        hitBomb.Clear(); // Eemaldame pommi
                        activeBombs.Remove(hitBomb);
                    }

                    if (extraLives > 0)
                    {
                        extraLives--; // Kui elusid on, kasutame ühe ära
                        DrawScore.UpdateLivesDisplay(extraLives);

                        snake.Clear(); // Kustutame madu pildi

                        startPoint = new Point(4, 5, '■'); // Paneme madu tagasi algusesse
                        var newsnake = new Snake.Snake(startPoint, snake.pList.Count, Direction.RIGHT);
                        snake = newsnake;
                        snake.Draw();
                        continue; // Jätkame mängu
                    }
                    else
                    {
                        name = gameOverShow.Show(path, gameChoose, score); // Kui elusid pole, näitame mängu lõppu
                        game_over = true;
                        break;
                    }
                }

                // Kui madu sõi tavalise toidu
                if (snake.Eat(food))
                {
                    soundPlay.Play(soundPath); // Mängime heliefekti

                    score++; // Lisame punkti
                    DrawScore.UpdateScoreDisplay(score); // Värskendame skoori kuvamist
                    gameChoose.IncreaseSpeed(); // Kiirendame mängu
                    food = foodcreator.CreateFood(); // Loome uue toidu
                    food.Draw(); // Joonistame toidu
                }
                // Kui madu sõi erilise toidu
                else if (specialFood != null && snake.Eat(specialFood))
                {
                    soundPlay.Play(specialSoundPath); // Mängime erilise toidu heli
                    extraLives++; // Lisame ühe elu juurde
                    DrawScore.UpdateLivesDisplay(extraLives);
                    specialFood = null; // Eemaldame erilise toidu
                }
                else
                {
                    snake.Move(); // Kui toit ei söödud, liigub madu edasi
                }
                Thread.Sleep(fast); // Mängu kiiruse kontrolliks paus
            }

            // Kui mäng on lõppenud, salvestame skoori ja mängime lõpuheli
            if (game_over)
            {
                soundPlay.Play(gameOverSoundPath);
                using (StreamWriter text = new StreamWriter(path, true))
                {
                    if (score != 0) { text.WriteLine($"{name}: {score}"); }
                }
            }
            Console.Clear(); // Tühjendame ekraani mängu alguseks

        } while (repeatGame.Repeat()); // Kui kasutaja soovib uuesti mängida

        static void Draw(Figure figure)
        {
            figure.Draw(); // Abimeetod joonistamiseks
        }
    }
}
