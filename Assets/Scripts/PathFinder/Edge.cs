using UnityEngine;

public struct Edge
{
    public Rectangle first { get; }
    public Rectangle second { get; }
    public Vector2 start { get; }
    public Vector2 end { get; }

    public Edge(Rectangle first, Rectangle second, Vector2 start, Vector2 end)
    {
        this.first = first;
        this.second = second;
        this.start = start;
        this.end = end;
    }
}
