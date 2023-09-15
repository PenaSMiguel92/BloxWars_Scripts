using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatCmd : Command {
    public RetreatCmd(Vector2Int target, double radius) : base(target, radius) { }
    public override void IssueOrders(BaseUnitTile unit) {
        Debug.Log("Retreating");
    }
}