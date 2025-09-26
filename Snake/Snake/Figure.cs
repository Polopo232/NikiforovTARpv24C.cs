namespace EsimeneTund.Snake;

class Figure
{
    public List<Point> pList;

    public virtual void Draw()
    {
        foreach (Point p in pList)
        {
            p.Draw();
        }
    }
    public virtual bool IsHit(Figure figure)
    {
        foreach (var p1 in pList)
        {
            foreach (var p2 in figure.pList)
            {
                if (p1.IsHit(p2))
                    return true;
            }
        }
        return false;
    }
}
