using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCmd : Command { 
    public override void issueOrders() {
        Debug.Log("Patrolling");
    }
}