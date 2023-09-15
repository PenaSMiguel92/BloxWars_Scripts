using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCmd : Command {

    public AttackCmd(Vector2 target, double radius) : base(target, radius) { }
    public override void IssueOrders(BaseUnitTile unit) {
        Debug.Log("attacking");
    }

}