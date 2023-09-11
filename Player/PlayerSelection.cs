using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection
{
    private List<BaseUnitTile> unitsSelected = new();


    public PlayerSelection() {

    }

    

    public void deselect() {

    }

    public void addSelectionFromArray(BaseUnitTile[] units) {
        
    }

    public List<BaseUnitTile> UnitsSelected { get { return this.unitsSelected; } }
}
