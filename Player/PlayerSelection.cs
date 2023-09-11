using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection
{
    private readonly List<BaseUnitTile> unitsSelected = new();


    public PlayerSelection() {

    }

    

    public void Deselect() {
        this.unitsSelected.Clear();
    }

    public void AddSelectionFromArray(BaseUnitTile[] units) {
        foreach (var unit in units) {
            this.unitsSelected.Add(unit);
        }
    }

    public List<BaseUnitTile> UnitsSelected { get { return this.unitsSelected; } }
}
