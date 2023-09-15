using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected Vector2 target;
    protected double radius;

    public Command(Vector2 target, double radius) {
        this.target = target;
        this.radius = radius;
    }
    public abstract void IssueOrders(BaseUnitTile unit);

}
