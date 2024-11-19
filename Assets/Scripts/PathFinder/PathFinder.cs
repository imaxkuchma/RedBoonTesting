using System.Collections.Generic;
using UnityEngine;

public class PathFinder : IPathFinder
{
    public IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, List<Edge> edges)
    {
        if (edges == null || edges.Count == 0)
        {
            return new List<Vector2>();
        }

        if (!IsPointInAnyRectangle(start, edges) || !IsPointInAnyRectangle(end, edges))
        {
            return new List<Vector2>();
        }

        List<Vector2> path = new List<Vector2> { start };
        Vector2 current = start;

        while (current != end)
        {
            Vector2 nextIntersection = FindNearestIntersection(current, end, edges);

            if (nextIntersection == Vector2.zero)
            {
                path.Add(end);
                break;
            }
            path.Add(nextIntersection);
            current = nextIntersection;
        }

        if (path[path.Count - 1] != end)
            path.Add(end);

        return path;
    }

    private bool IsPointInAnyRectangle(Vector2 point, List<Edge> edges)
    {
        foreach (var edge in edges)
        {
            if (IsPointInRectangle(point, edge.first) || IsPointInRectangle(point, edge.second))
                return true;
        }
        return false;
    }

    private bool IsPointInRectangle(Vector2 point, Rectangle rectangle)
    {
        return point.x >= rectangle.min.x && point.x <= rectangle.max.x &&
               point.y >= rectangle.min.y && point.y <= rectangle.max.y;
    }

    private Vector2 FindNearestIntersection(Vector2 start, Vector2 end, List<Edge> edges)
    {
        Vector2 nearestPoint = Vector2.zero;
        float nearestDistance = float.MaxValue;

        foreach (var edge in edges)
        {
            if (IsPointInRectangle(edge.start, edge.first) || IsPointInRectangle(edge.start, edge.second))
            {
                float distance = Vector2.Distance(start, edge.start);
                if (distance < nearestDistance && IsPointCloserToEnd(edge.start, start, end))
                {
                    nearestDistance = distance;
                    nearestPoint = edge.start;
                }
            }

            if (IsPointInRectangle(edge.end, edge.first) || IsPointInRectangle(edge.end, edge.second))
            {
                float distance = Vector2.Distance(start, edge.end);
                if (distance < nearestDistance && IsPointCloserToEnd(edge.end, start, end))
                {
                    nearestDistance = distance;
                    nearestPoint = edge.end;
                }
            }
        }

        return nearestPoint;
    }

    private bool IsPointCloserToEnd(Vector2 point, Vector2 current, Vector2 end)
    {
        return Vector2.Distance(point, end) < Vector2.Distance(current, end);
    }
}
