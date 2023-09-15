using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCmd : Command {

    private List<Node> movePath;
    public MoveCmd(Vector2Int target, double radius) : base(target, radius) { }
    public override void IssueOrders(BaseUnitTile unit) {
        Dictionary<string, TileInfo> mapData = MainMap.SummaryMap;
        movePath = ThetaStarPathfinding.ThetaStarAlgorithm(unit.LocalPosition, target, mapData, false);
    }

    public override IEnumerator ExecuteOrders() {
        Debug.Log("executing moving orders");
        yield return new WaitForEndOfFrame();
    }
}