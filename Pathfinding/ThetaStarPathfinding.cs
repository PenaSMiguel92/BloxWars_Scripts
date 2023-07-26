using System.Collections.Generic;
using UnityEngine;

public static class ThetaStarPathfinding
{
    public static List<Node> ThetaStarAlgorithm(Vector2 initial,Vector2 final, Dictionary<string, BaseTile> mapData, bool flyingUnit) //efficient pathfinding algorithm, seems to be near instantaneous, but likely O(log(N)) time complexity.
    {
        List<Vector2> _closed = new List<Vector2>();
        BinaryHeap _open = new BinaryHeap();
        Node _startNode = new Node(initial, initial, final);
        _startNode.parent = _startNode;
        _open.Insert(_startNode);
        while (!_open.IsEmpty())
        {
            var _currentNode = _open.Pop();
            if (_currentNode.distToEnd <= 0)
            {
                return ReconstructPath(new List<Node>(), _currentNode);
            }
            _closed.Add(_currentNode.location);
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Vector2 _nxtLoc = _currentNode.location + new Vector2(x, y);
                    string _nxtLocStr = _nxtLoc.x.ToString() + "," + _nxtLoc.y.ToString();
                    BaseTile _value;
                    if ((_nxtLoc != _currentNode.location) && (mapData.TryGetValue(_nxtLocStr, out _value)))
                    {
                        if (_value.Crossable || flyingUnit)
                        {
                            Node _nxtNode = new Node(_nxtLoc, initial, final);
                            if (!_closed.Contains(_nxtNode.location))
                            {
                            
                                float _gScore = _currentNode.distToStart + _currentNode.computeEuclideanHeuristic(_currentNode.location, _nxtNode.location);
                                if (!_open.Contains(_nxtNode))
                                {
                                    _nxtNode.distToStart = float.MaxValue;
                                    _nxtNode.parent = null;
                                }
                                if (_gScore < _nxtNode.distToStart)
                                {
                                    _nxtNode.distToStart = _gScore;
                                    _nxtNode.parent = _currentNode;
                                    _nxtNode.Cost = _nxtNode.distToStart + _nxtNode.distToEnd;
                                    if (_open.Contains(_nxtNode))
                                    {
                                        _open.Remove(_nxtNode);
                                    }
                                    _open.Insert(_nxtNode);
                                }
                            
                            }
                        }
                        
                    }
                }
            }

        }
        return null;
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