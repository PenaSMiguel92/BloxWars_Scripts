using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected Vector2 _target;
    protected double _radius;
    public abstract void issueOrders();

}
