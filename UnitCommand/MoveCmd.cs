using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCmd : Command {

    private Queue<Node> movePath;
    private BaseUnitTile bindedUnit;
    public MoveCmd(Vector2Int target, double radius) : base(target, radius) { }
    public override void IssueOrders(BaseUnitTile unit) {
        Dictionary<string, TileInfo> mapData = MainMap.SummaryMap;
        bindedUnit = unit;
        movePath = ThetaStarPathfinding.ThetaStarAlgorithm(unit.LocalPosition, target, mapData, false);
    }

    public override IEnumerator ExecuteOrders() {
        bindedUnit.CoroutineRunning = true;
        do
        {
            if (movePath.TryDequeue(out Node nxtNode)) {
                Debug.Log(nxtNode.location);
            }
            yield return new WaitForEndOfFrame();
        } while (movePath.Count > 0);
        bindedUnit.CoroutineRunning = false;
    }
}