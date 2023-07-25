using UnityEngine;

public class Node //for use with pathfinding algorithm
{
    public float distToEnd;
    public float distToStart;
    public float Cost;
    public Vector2 location;
    public Node parent;

    public Node(Vector2 _location,Vector2 _start, Vector2 _end)
    {
        distToEnd = computeManhattanHeuristic(_location, _end); //hScore
        distToStart = computeManhattanHeuristic(_start,_location); //gScore
        Cost = distToEnd + distToStart; //tScore
        location = _location;
    }

    public float computeManhattanHeuristic(Vector2 _initial, Vector2 _final)
    {
        Vector2 difference = _final - _initial;
        return Mathf.Abs(difference.x) + Mathf.Abs(difference.y);
    }

    public float computeEuclideanHeuristic(Vector2 _initial, Vector2 _final)
    {
        Vector2 difference = _final - _initial;
        return difference.magnitude;
    }
}