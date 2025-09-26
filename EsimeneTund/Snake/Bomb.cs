namespace EsimeneTund.Snake;

internal class Bomb
{
    int mapWidht;
    int mapHeight;
    char sym;
    public Point Position { get; private set; }

    Random rnd = new Random();

    public Bomb(int mapWidht, int mapHeight, char sym)
    {
        this.mapWidht = mapWidht;
        this.mapHeight = mapHeight;
        this.sym = sym;
        this.Position = CreateBomb();
    }

    public Point CreateBomb()
    {
        int x = rnd.Next(2, mapWidht - 2);
        int y = rnd.Next(2, mapHeight - 2);
        return new Point(x, y, sym);
    }
    public void Draw()
    {
        Position.Draw();
    }
    public void Clear()
    {
        Position.Clear();
    }
}