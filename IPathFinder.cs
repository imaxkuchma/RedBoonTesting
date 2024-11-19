using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Edge
{
    public Rectangle first;
    public Rectangle second;
    public Vector2 start;
    public Vector2 end;

    public Edge(Rectangle first, Rectangle second, Vector2 start, Vector2 end)
    {
        this.first = first;
        this.second = second;
        this.start = start;
        this.end = end;
    }
}

public interface IPathFinder
{
    IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, List<Edge> edges);
}



