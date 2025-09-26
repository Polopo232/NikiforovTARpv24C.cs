namespace EsimeneTund.Snake;

internal class SpecialFoodCreator
{
    int mapWidth;
    int mapHeight;
    char sym;
    Random rnd = new Random();

    public SpecialFoodCreator(int mapWidth, int mapHeight, char sym)
    {
        this.mapWidth = mapWidth;
        this.mapHeight = mapHeight;
        this.sym = sym;
    }

    public Point CreateSpecialFood()
    {
        int x = rnd.Next(2, mapWidth - 2);
        int y = rnd.Next(2, mapHeight - 2);
        return new Point(x, y, sym);
    }
}