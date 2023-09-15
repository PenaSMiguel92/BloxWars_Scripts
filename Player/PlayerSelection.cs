using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection
{
    private readonly List<BaseUnitTile> unitsSelected = new();


    public PlayerSelection() {
        
    }

    public void Select(BaseUnitTile unit, Player owner) {
        unit.Select(owner);
        unitsSelected.Add(unit);
    }

    public void Deselect() {
        unitsSelected.Clear();
    }

    public void AddSelectionFromArray(BaseUnitTile[] units) {
        foreach (var unit in units) {
            unitsSelected.Add(unit);
        }
    }

    public List<BaseUnitTile> UnitsSelected { get { return unitsSelected; } }
}
