using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType {AntiAirTurret, Barracks, ConstructionYard, HeavyVehicleFactory, LightVehicleFactory, PowerPlant, RadarOutpost, Refinery, Slab_1x1, Slab_2x2, Storage, Turret}

public interface IBuildingTile
{
    public string Name { get; }
    public float Health { get; }
    public bool Origin { get; }
}


public class DummyBuildingPiece : BaseTile, IBuildingTile
{
    Transform _transform;
    string _name;
    bool _origin = false;
    float _health = 1;
    BaseBuildingTile _originMainTile;
    BuildingType _type;

    public void Awake()
    {
        this._transform = gameObject.GetComponent<Transform>();
        this._crossable = false;
        this._localPosition = MainMap.WorldToLocalPosition(this._transform.localPosition);
    }
    public override void Initialize()
    {
        BuildingTileDefinition _def = (BuildingTileDefinition) this._definition;
        this._name = _def._name;
        this._type = _def._buildingType;
    }

    public string Name { get { return _name; } set { _name = value; } }
    public float Health { get { return _health; } }
    public bool Origin { get { return _origin; } }
    public BaseBuildingTile OriginMainTile {get { return _originMainTile; } set { _originMainTile = value; } }
}

public abstract class BaseBuildingTile : BaseTile, IBuildingTile
{
    protected Transform _transform;
    protected bool _origin = true;
    protected BuildingType _type;
    protected string _name;
    protected string _structure;
    protected bool[,] _structureArray;
    protected float _health;
    protected float _attack;
    protected float _defense;

    public void Awake()
    {
        this._tileType = TileType.Building;
        this._crossable = false;
        this._transform = gameObject.GetComponent<Transform>();
        this._localPosition = MainMap.WorldToLocalPosition(_transform.localPosition);
    }

    public override void Initialize()
    {
        BuildingTileDefinition _def = (BuildingTileDefinition) this._definition;
        this._name = _def._name;
        this._attack = _def._attack;
        this._defense = _def._defense;
        this._structure = _def._structure;
        this._type = _def._buildingType;
        ParseStructureString();
    }
    public string Name { get { return _name; } }
    public bool Origin {get { return _origin; } }
    public float Health { get { return _health; } }
    public float Attack { get { return _attack; } }
    public float Defense { get { return _defense; } }

    public void ParseStructureString()
    {
        _structureArray = new bool[,] {
            {false, false, false},
            {false, false, false},
            {false, false, false}
        };

        string[] _values = this._structure.Split(',');
        for (int _i = 0; _i < _values.Length; _i++)
        {
            int _val = int.Parse(_values[_i]);
            if (_val == 1)
            {
                int x = _i % 3;
                int y = _i / 3;
                _structureArray[y, x] = true;
            }
            else
                continue;

        }
    }
}