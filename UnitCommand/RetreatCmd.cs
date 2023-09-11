using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatCmd : Command {
    public override void issueOrders() {
        Debug.Log("Retreating");
    }
}