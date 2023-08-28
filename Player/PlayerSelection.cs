using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection
{
    private List<BaseUnitTile> unitsSelected = new();


    public PlayerSelection() {

    }

    public void issueOrders(PlayerOrders order, Vector2 location, double radius) {

    }

    public void deselect() {

    }

    public void addSelectionFromArray(BaseUnitTile[] units) {
        
    }

    public List<BaseUnitTile> UnitsSelected { get { return this.unitsSelected; } }
}
