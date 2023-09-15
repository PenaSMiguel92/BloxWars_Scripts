using System;
using System.Collections.Generic;
using UnityEngine;

public static class ThetaStarPathfinding
{
    private static readonly List<Vector2> closed = new();
    private static readonly BinaryHeap open = new();
    private static Dictionary<string, BaseTile> mapData;
    public static List<Node> ThetaStarAlgorithm(Vector2 initial, Vector2 final, Dictionary<string, BaseTile> mapData, bool flyingUnit) //efficient pathfinding algorithm, seems to be near instantaneous, but likely O(log(N)) time complexity.
    {
        closed.Clear();
        open.Clear();
        ThetaStarPathfinding.mapData = mapData;

        Node startNode = new(initial, initial, final);
        startNode.parent = startNode;
        open.Insert(startNode);
        while (!open.IsEmpty())
        {
            var currentNode = open.Pop();
            if (currentNode.distToEnd <= 0)
                return ReconstructPath(new List<Node>(), currentNode);

            closed.Add(currentNode.location);

            InspectSurroundingNodes(initial, final, currentNode, flyingUnit);
        }
        return null;
    }

    public static void InspectSurroundingNodes(Vector2 initial, Vector2 final, Node currentNode, bool flyingUnit) {
        for (int angle = 0; angle <= 3; angle++)
        {
            Vector2 offset = new(Mathf.Floor(Mathf.Cos(angle*Mathf.PI)), 
                                 Mathf.Floor(Mathf.Sin(angle*Mathf.PI)));
            
            Vector2 nxtLoc = currentNode.location + offset;
            if (nxtLoc == currentNode.location)
                continue;

            string nxtLocStr = nxtLoc.x.ToString() + "," + nxtLoc.y.ToString();
            if (mapData.TryGetValue(nxtLocStr, out BaseTile value))
            {
                if (!(value.Crossable || flyingUnit))
                    continue;

                Node nxtNode = new(nxtLoc, initial, final);
                if (closed.Contains(nxtNode.location))
                    continue;

                float gScore = currentNode.distToStart + currentNode.ComputeEuclideanHeuristic(currentNode.location, nxtNode.location);
                if (!open.Contains(nxtNode))
                {
                    nxtNode.distToStart = float.MaxValue;
                    nxtNode.parent = null;
                }
                if (gScore < nxtNode.distToStart)
                {
                    nxtNode.distToStart = gScore;
                    nxtNode.parent = currentNode;
                    nxtNode.Cost = nxtNode.distToStart + nxtNode.distToEnd;
                    if (open.Contains(nxtNode))
                        open.Remove(nxtNode);
                    
                    open.Insert(nxtNode);
                }
            }
        }
    }

    public static List<Node> ReconstructPath(List<Node> totalPath, Node nxtNode)
    {
        totalPath.Add(nxtNode);
        if (nxtNode.parent != nxtNode)
        {
            return ReconstructPath(totalPath, nxtNode.parent);
        }
        else
        {
            return totalPath;
        }
    }
}