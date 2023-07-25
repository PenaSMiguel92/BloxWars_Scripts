using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundTile : BaseTile
{
    private float _rndAngle;
    private float _resourceAmount;
    private bool _resource;
    private bool _constructable;

    public override void Initialize()
    {
        BackgroundTileDefinition _def = (BackgroundTileDefinition) _definition;
        this._crossable = _def.Crossable;
        this._localPosition = MainMap.WorldToLocalPosition(transform.localPosition);
        this._worldPosition = transform.localPosition;
        _rndAngle = Mathf.RoundToInt(Random.value * 4) * (Mathf.PI / 2);
        transform.localRotation = Quaternion.AngleAxis(_rndAngle * Mathf.Rad2Deg, Vector3.up);
        this._constructable = _def.Constructable;
        this._resource = _def.Resource;
        this._resourceAmount = _def.ResourceAmount;
    }

    

    public bool IsAResource { get { return _resource; } }
    public bool Constructable {get { return _constructable; } }
    public float ResourceAmount {get { return _resourceAmount; } }
}
