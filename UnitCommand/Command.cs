using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected Vector2Int target;
    protected double radius;

    public Command(Vector2Int target, double radius) {
        this.target = target;
        this.radius = radius;
    }
    public abstract void IssueOrders(BaseUnitTile unit);
    public abstract IEnumerator ExecuteOrders();

}
