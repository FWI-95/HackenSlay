using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using HackenSlay.World.Map;

namespace HackenSlay.World.Navigation;

internal static class Pathfinder
{
    private readonly struct Node
    {
        public readonly Point Pos;
        public readonly int F;
        public readonly int G;
        public Node(Point pos, int g, int f)
        {
            Pos = pos;
            G = g;
            F = f;
        }
    }

    public static List<Point> FindPath(TileType[,] tiles, Point start, Point goal)
    {
        int width = tiles.GetLength(0);
        int height = tiles.GetLength(1);
        var open = new PriorityQueue<Node, int>();
        var cameFrom = new Dictionary<Point, Point>();
        var gScore = new Dictionary<Point, int> { [start] = 0 };

        open.Enqueue(new Node(start, 0, Heuristic(start, goal)), Heuristic(start, goal));

        while (open.Count > 0)
        {
            var current = open.Dequeue();
            if (current.Pos == goal)
                return Reconstruct(cameFrom, current.Pos);

            foreach (var neighbor in GetNeighbors(current.Pos, width, height))
            {
                if (!IsWalkable(tiles, neighbor))
                    continue;

                int tentative = gScore[current.Pos] + 1;
                if (!gScore.TryGetValue(neighbor, out int g) || tentative < g)
                {
                    cameFrom[neighbor] = current.Pos;
                    gScore[neighbor] = tentative;
                    int f = tentative + Heuristic(neighbor, goal);
                    open.Enqueue(new Node(neighbor, tentative, f), f);
                }
            }
        }
        return new List<Point>();
    }

    private static bool IsWalkable(TileType[,] tiles, Point p)
    {
        TileType type = tiles[p.X, p.Y];
        return type != TileType.Obstacle;
    }

    private static IEnumerable<Point> GetNeighbors(Point p, int width, int height)
    {
        if (p.X > 0) yield return new Point(p.X - 1, p.Y);
        if (p.X < width - 1) yield return new Point(p.X + 1, p.Y);
        if (p.Y > 0) yield return new Point(p.X, p.Y - 1);
        if (p.Y < height - 1) yield return new Point(p.X, p.Y + 1);
    }

    private static int Heuristic(Point a, Point b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    private static List<Point> Reconstruct(Dictionary<Point, Point> cameFrom, Point current)
    {
        var path = new List<Point> { current };
        while (cameFrom.TryGetValue(current, out var prev))
        {
            current = prev;
            path.Add(current);
        }
        path.Reverse();
        return path;
    }
}
