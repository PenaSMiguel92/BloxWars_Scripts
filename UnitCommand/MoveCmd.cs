using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCmd : Command {

    public MoveCmd(Vector2Int target, double radius) : base(target, radius) { }
    public override void IssueOrders(BaseUnitTile unit) {
        Dictionary<string, TileInfo> mapData = MainMap.SummaryMap;
        List<Node> path = ThetaStarPathfinding.ThetaStarAlgorithm(unit.LocalPosition, target, mapData, false);
        Debug.Log("moving");
    }
}