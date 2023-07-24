using System;
using System.Collections;
using UnityEngine;

public struct MCVTrailer
{
    Vector2 TrailerPosition;
    Quaternion TrailerRotation;

}

public class MobileConstVehicleUnit : BaseUnitTile
{
    MCVTrailer _trailer;
    public MobileConstVehicleUnit(Vector2 position, UnitTileDefinition def) : base(position, def)
    {
        //this._structure 
        _trailer = new MCVTrailer();
    }
    public override void MoveTo(Vector2 position)
    {
        throw new NotImplementedException();
    }

    public override void LookAt(Vector2 position)
    {
        throw new NotImplementedException();
    }

    public override void Awake()
    {
        throw new NotImplementedException();
    }

    public override void Start()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}