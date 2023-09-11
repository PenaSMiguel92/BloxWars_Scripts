using System.Collections;
using System.Collections;
using UnityEngine;

public class GuardCmd : Command {
    public override void issueOrders() {
        Debug.Log("Guarding.");
    }
}