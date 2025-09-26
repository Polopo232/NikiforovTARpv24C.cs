namespace EsimeneTund.Snake;

internal class DrawScore
{
    public static void DrawScoreBorder()
    {
        int scorePanelX = 82;
        int scorePanelWidth = 15;

        Console.SetCursorPosition(scorePanelX, 0);
        Console.Write("╔");
        for (int i = 0; i < scorePanelWidth - 2; i++)
            Console.Write("═");
        Console.Write("╗");

        for (int y = 1; y < 24; y++)
        {
            Console.SetCursorPosition(scorePanelX, y);
            Console.Write("║");
            Console.SetCursorPosition(scorePanelX + scorePanelWidth - 1, y);
            Console.Write("║");

            for (int x = scorePanelX + 1; x < scorePanelX + scorePanelWidth - 1; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
            }
        }

        Console.SetCursorPosition(scorePanelX, 24);
        Console.Write("╚");
        for (int i = 0; i < scorePanelWidth - 2; i++)
            Console.Write("═");
        Console.Write("╝");

        Console.SetCursorPosition(scorePanelX + 3, 2);
        Console.Write("SCORE");

        Console.SetCursorPosition(scorePanelX + 1, 6);
        for (int i = 0; i < scorePanelWidth - 2; i++)
            Console.Write("═");

        Console.SetCursorPosition(scorePanelX + 1, 8);
        Console.Write("Extra lives:");
    }

    public static void UpdateScoreDisplay(int score)
    {
        int scorePanelX = 85;
        int scoreY = 4;

        Console.SetCursorPosition(scorePanelX, scoreY);
        Console.Write("          ");
        Console.SetCursorPosition(scorePanelX, scoreY);
        Console.Write(score.ToString());
    }

    public static void UpdateLivesDisplay(int lives)
    {
        int livesPanelX = 90;
        int livesY = 10;

        Console.SetCursorPosition(livesPanelX, livesY);
        Console.Write("  ");
        Console.SetCursorPosition(livesPanelX, livesY);
        Console.Write(lives.ToString());
    }
}