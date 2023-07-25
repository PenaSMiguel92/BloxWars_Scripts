using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ThetaStarPathfinding
{
    // public IEnumerator FindPathTowardsTargetPosition(Vector2 inputTile)
    // {
    //     if (UnitModel != null)
    //     {
    //         moving = true;
    //         bool targetSet = false;
    //         int currentIndex = 0;
    //         float targetAngle;
    //         float currentTValue = 0f;
    //         Node currentNode;
    //         Quaternion targetNextNodeRotation = new Quaternion();
    //         Vector3 targetNextNodeLocation = new Vector3();
    //         Vector3 targetEndLocation = inputTile.groundTile.transform.position;
    //         Vector3 currentLocation = UnitModel.transform.position;
    //         Vector3 startLocation = UnitModel.transform.position;
    //         Quaternion currentRotation = UnitModel.transform.rotation;
    //         Vector3 differenceLoc;// = new Vector3();// = targetEndLocation - startLocation;
    //         Vector2 startLoc = MainGame.main.mainMap.GetGridPositionFromFloatLocation(startLocation);
    //         Vector2 endLoc = MainGame.main.mainMap.GetGridPositionFromFloatLocation(targetEndLocation);
    //         nextPos = endLoc;
    //         List<Node> totalPath = ThetaStarAlgorithm(startLoc, endLoc);
    //         if (totalPath == null) { moving = false; Debug.Log("TotalPath Returned Null"); yield break; }
    //         InvokeUnitPathFound();
    //         totalPath.Reverse();
    //         animState = UnitAnimationState.Moving;
    //         OnAnimationStateChanged();
    //         while (moving)
    //         {
    //             if (!targetSet)
    //             {
    //                 currentNode = totalPath[currentIndex];
    //                 targetNextNodeLocation = MainGame.main.mainMap.GetFloatLocationFromGridPosition(currentNode.location);
    //                 currentLocation = UnitModel.transform.position;
    //                 currentRotation = UnitModel.transform.rotation;
    //                 differenceLoc = targetNextNodeLocation - UnitModel.transform.position;
    //                 targetAngle = Mathf.Atan2(differenceLoc.z, -differenceLoc.x) - Mathf.PI / 2;
    //                 targetAngle = targetAngle < 0 ? (2 * Mathf.PI + targetAngle) : targetAngle;
    //                 targetNextNodeRotation = Quaternion.Euler(0, Mathf.Rad2Deg * targetAngle, 0);
    //                 currentTValue = 0;
    //                 targetSet = true;
    //             }
    //             else
    //             {
    //                 currentTValue += Time.deltaTime * UnitMovementSpeed;
    //                 currentTValue = currentTValue > 1 ? 1 : currentTValue;
    //                 Quaternion rotationToUse = Quaternion.Lerp(currentRotation, targetNextNodeRotation, currentTValue * UnitRotationSpeed);
    //                 Vector3 locationToUse = Vector3.Lerp(currentLocation, targetNextNodeLocation, currentTValue);
    //                 UnitModel.transform.position = locationToUse;
    //                 UnitModel.transform.rotation = rotationToUse;
    //                 if ((targetNextNodeLocation - UnitModel.transform.position).magnitude <= 0f)
    //                 {
    //                     targetSet = false;
    //                     currentIndex++;
    //                 }
    //             }
               
    //             if (currentIndex > totalPath.Count - 1)
    //             {
    //                 gridPos = MainGame.main.mainMap.GetGridPositionFromFloatLocation(targetNextNodeLocation);
    //                 groundHeight = MainGame.main.mainMap.GetHeightAtLocation(gridPos);
    //                 gridRot = targetNextNodeRotation;
    //                 animState = UnitAnimationState.Idle;
    //                 OnAnimationStateChanged();
    //                 moving = false;
    //                 yield break;
    //             }

    //             yield return new WaitForEndOfFrame();
    //         }
    //     }
    // }

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