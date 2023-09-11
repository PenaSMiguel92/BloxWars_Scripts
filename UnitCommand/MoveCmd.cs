using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCmd : Command {
    public override void issueOrders() {
        Debug.Log("moving");
    }
}