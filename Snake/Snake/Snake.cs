namespace EsimeneTund.Snake;

class Snake : Figure
{
    Direction direction;
    public Snake(Point tail, int lenght, Direction _direction)
    {
       direction = _direction;
        pList = new List<Point>();
        for (int i = 0; i < lenght; i++)
        {
            Point p = new Point(tail);
            p.Move(i, direction);
            pList.Add(p);
            
        }
    }
    internal void Move()
    {
        Point tail = pList.First();
        pList.Remove(tail);
        Point head = GetNextPoint();
        pList.Add(head);

        tail.Clear();
        head.Draw();
    }
    public Point GetNextPoint()
    {
        Point head = pList.Last();
        Point nextPoint = new Point(head);
        nextPoint.Move(1, direction);
        return nextPoint;
    }
    internal bool IsHitTail()
    {
        var head = pList.Last();
        for (int i = 0; i < pList.Count - 2; i++)
        {
            if (head.IsHit(pList[ i ]))
                return true;

        }
        return false;
    }

    public void HandelKey(ConsoleKey key)
    {
        if (key == ConsoleKey.LeftArrow && direction != Direction.RIGHT)
            direction = Direction.LEFT;
        else if (key == ConsoleKey.RightArrow && direction != Direction.LEFT)
            direction = Direction.RIGHT;
        else if (key == ConsoleKey.UpArrow && direction != Direction.DOWN)
            direction = Direction.UP;
        else if (key == ConsoleKey.DownArrow && direction != Direction.UP)
            direction = Direction.DOWN;
    }
    internal bool Eat (Point food)
    {
        Point head = GetNextPoint();
        if (head.IsHit(food))
        {
            food.sym = head.sym;
            pList.Add(food);
            return true;
        }
        else {
            return false;
        }
    }
    public Point Head
    {
        get { return pList.Last(); }
    }

    public void Clear()
    {
        foreach (Point p in pList)
        {
            p.Clear();
        }
    }

}