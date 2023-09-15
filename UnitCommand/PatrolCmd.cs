using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCmd : Command { 
    public PatrolCmd(Vector2Int target, double radius) : base(target, radius) { }
    public override void IssueOrders(BaseUnitTile unit) {
        Debug.Log("Patrolling");
    }
}