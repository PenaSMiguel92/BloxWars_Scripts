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


public class DummyBuildingPiece : IBuildingTile
{
    string _name;
    bool _origin;
    float _health = 1;
    Vector2 _originPosition;
    Vector2 _localPosition;
    public DummyBuildingPiece(string name, bool origin, Vector2 originPosition, Vector2 localPosition)
    {
        this._name = name;
        this._origin = origin;
        this._originPosition = originPosition;
        this._localPosition = localPosition;
    }
    public Vector2 OriginPosition { get { return _originPosition; } }
    public Vector2 LocalPosition { get { return _localPosition; } }
    public string Name { get { return _name; } }
    public float Health { get { return _health; } }
    public bool Origin { get { return _origin; } }
}

public abstract class BaseBuildingTile : BaseTile, IBuildingTile
{
    protected Transform _transform;
    protected bool _origin;
    protected BuildingType _type;
    protected GameObject _modelUse;
    protected string _name;
    protected string _structure;
    protected bool[,] _structureArray;
    protected float _health;
    protected float _attack;
    protected float _defense;

    public void Awake()
    {
        _transform = gameObject.GetComponent<Transform>();
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
        Debug.Log(_structureArray);
    }
}