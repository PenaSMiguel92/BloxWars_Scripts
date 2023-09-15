using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCmd : Command {

    public AttackCmd(Vector2Int target, double radius) : base(target, radius) { }
    public override void IssueOrders(BaseUnitTile unit) {
        Debug.Log("issuing attacking orders");
    }

    public override IEnumerator ExecuteOrders() {
        Debug.Log("executing attack orders");
        yield return new WaitForEndOfFrame();
    }

}