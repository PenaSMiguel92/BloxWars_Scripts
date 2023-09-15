using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCmd : Command {

    public GuardCmd(Vector2Int target, double radius) : base(target, radius) { }
    public override void IssueOrders(BaseUnitTile unit) {
        Debug.Log("issuing guarding orders");
    }

    public override IEnumerator ExecuteOrders() {
        Debug.Log("executing guarding orders");
        yield return new WaitForEndOfFrame();
    }
}