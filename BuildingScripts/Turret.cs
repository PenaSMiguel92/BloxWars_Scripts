using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : BaseBuildingTile
{
    public void Start()
    {
        this._type = BuildingType.Turret;
    }

}