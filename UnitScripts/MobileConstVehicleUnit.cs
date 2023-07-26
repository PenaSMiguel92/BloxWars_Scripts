using System;
using UnityEngine;

public struct MCVTrailer
{
    Vector2 TrailerPosition;
    Quaternion TrailerRotation;

}

public class MobileConstVehicleUnit : BaseUnitTile
{
    MCVTrailer _trailer;


    public override void Start()
    {
        this._type = UnitType.MCV;
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}