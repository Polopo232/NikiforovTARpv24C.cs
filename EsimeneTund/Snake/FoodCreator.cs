namespace EsimeneTund.Snake;

internal class FoodCreator
{
    int mapWidht;
    int mapHeight;
    char sym;

    Random rnd = new Random();

    public FoodCreator(int mapWidht, int mapHeight, char sym)
    {
        this.mapWidht = mapWidht;
        this.mapHeight = mapHeight; 
        this.sym = sym;
    }

    public Point CreateFood()
    {
        int x = rnd.Next(2, mapWidht - 2);
        int y = rnd.Next(2, mapHeight - 2);
        return new Point(x, y, sym);
    }
}
