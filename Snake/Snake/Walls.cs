using System.Runtime.CompilerServices;

namespace EsimeneTund.Snake;

class Walls
{
    List<Figure> wallList;

    public Walls(int mapWidth, int mapHeight)
    {
        wallList = new List<Figure>();

        HorizontalLine upLine = new HorizontalLine(0, mapWidth - 1, 0, '▄');
        HorizontalLine downLine = new HorizontalLine(0, mapWidth - 1,mapHeight - 1, '▄');
        VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '█');
        VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 1, '█');

        wallList.Add(upLine);
        wallList.Add(downLine);
        wallList.Add(leftLine);
        wallList.Add(rightLine);

    }

    internal bool IsHit(Figure figure)
    {
        foreach (var wall in wallList)
        {
            if (wall.IsHit(figure))
            { 
                return true;
            }
        }
        return false;
    }

    private bool IsHit(Point point) {
        foreach (var wall in wallList)
        {
            foreach (var p in wall.pList)
            {
                if (p.IsHit(point))
                {
                    return true;
                }
            }
            
        }
        return false;
    }

    public void Draw()
    {
        foreach (var wall in wallList)
        {
            wall.Draw();
        }
    }
}
