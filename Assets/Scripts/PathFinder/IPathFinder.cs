using System.Collections.Generic;
using UnityEngine;

public interface IPathFinder
{
    IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, List<Edge> edges);
}