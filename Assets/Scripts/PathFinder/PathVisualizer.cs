using System.Collections.Generic;
using UnityEngine;

public class PathVisualizer : MonoBehaviour
{
    public List<Edge> edges = new List<Edge>();
    public Vector2 startPoint;
    public Vector2 endPoint;
    private List<Vector2> foundPath = new List<Vector2>();

    private void Start()
    {
        FindPath();
    }

    private void OnValidate()
    {
        FindPath();
    }

    [ContextMenu("FindPath")]
    public void FindPath()
    {
        edges = new List<Edge>
        {
            new Edge(
                new Rectangle(new Vector2(-15, 15), new Vector2(2, 25)),
                new Rectangle(new Vector2(-3, 25), new Vector2(17, 35)),
                new Vector2(-3, 25),
                new Vector2(2, 25)
            ),
            new Edge(
                new Rectangle(new Vector2(-3, 25), new Vector2(17, 35)),
                new Rectangle(new Vector2(17, 20), new Vector2(37, 30)),
                new Vector2(17, 25),
                new Vector2(17, 30)
            ),
        };

        IPathFinder pathFinder = new PathFinder();
        IEnumerable<Vector2> result = pathFinder.GetPath(startPoint, endPoint, edges);

        foundPath = new List<Vector2>(result);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (var edge in edges)
        {
            DrawRectangle(edge.first);
            DrawRectangle(edge.second);
        }

        Gizmos.color = Color.green;
        foreach (var edge in edges)
        {
            Gizmos.DrawLine(edge.start, edge.end);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(startPoint, 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(endPoint, 0.5f);

        if (foundPath != null && foundPath.Count > 0)
        {
            Gizmos.color = Color.yellow;
            for (int i = 0; i < foundPath.Count - 1; i++)
            {
                Gizmos.DrawLine(foundPath[i], foundPath[i + 1]);
            }
        }
    }

    private void DrawRectangle(Rectangle rect)
    {
        Vector2 topLeft = new Vector2(rect.min.x, rect.max.y);
        Vector2 topRight = rect.max;
        Vector2 bottomLeft = rect.min;
        Vector2 bottomRight = new Vector2(rect.max.x, rect.min.y);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
