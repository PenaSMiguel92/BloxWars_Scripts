using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType { Barracks, ConstructionYard, HeavyVehicleFactory, LightVehicleFactory, PowerPlant, RadarOutpost, Refinery, RocketTurret, Slab_1x1, Slab_2x2, Storage, Turret}

public abstract class BaseBuildingTile : BaseTile
{
    protected Transform _transform;
    protected bool _origin = true;
    protected BuildingType _type;
    protected string _name;
    // protected string _structure;
    // protected bool[,] _structureArray;
    protected float _health;
    protected float _attack;
    protected float _defense;

    

    public override void Initialize()
    {
        BuildingTileDefinition _def = (BuildingTileDefinition) this._definition;
        this._name = _def._name;
        this._attack = _def._attack;
        this._defense = _def._defense;
        this._type = _def._buildingType;
        this._structure = _def._structure;
        this._tileType = TileType.Building;
        this._crossable = false;
        this._transform = gameObject.GetComponent<Transform>();
        this._localPosition = MainMap.WorldToLocalPosition(_transform.localPosition);
        Vector3 _offset = new Vector3((float)(this._structure.x / 2f), 0, (float)(this._structure.x / 2f));
        this._transform.localPosition = this._transform.localPosition + _offset;
    }

    
    public string Name { get { return _name; } }
    public bool Origin {get { return _origin; } }
    public float Health { get { return _health; } }
    public float Attack { get { return _attack; } }
    public float Defense { get { return _defense; } }
}