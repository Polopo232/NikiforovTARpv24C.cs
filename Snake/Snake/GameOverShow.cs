using EsimeneTund.Snake;

namespace Snake.Snake;

internal class GameOverShow
{
    public string Show(string path, GameChoose gameChoose, int score)
    {
        Console.Clear();
        gameChoose.WriteCentered($"Score: {score}");
        gameChoose.WriteCentered("Liidrite nimekiri: ");

        string name = "";

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
        }

        gameChoose.WriteCentered("Sisesta nimi: ");
        name = Console.ReadLine();

        return name;
    }

}
