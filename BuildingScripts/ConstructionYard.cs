using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionYard : BaseBuildingTile
{
    public void Start()
    {
        this._type = BuildingType.ConstructionYard;
    }

}