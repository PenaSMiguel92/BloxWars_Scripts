using System;
using System.Collections;
using UnityEngine;

public enum UnitType {CarryAll, Gunman, Harvester, HeavyInfantry, Infantry, Launcher, Missiler, MCV, Quad, SiegeTank, Tank, Trike}
public interface IUnitTile
{
    public float Health { get; }
    public float Attack { get; }
    public float Defense { get; }
    public float Speed { get; }
    public Vector2 LocalPosition { get; }
}

public abstract class BaseUnitTile : BaseTile, IUnitTile 
{
    protected string _structure;
    protected string _name;
    protected float _health = 1;
    protected float _attack;
    protected float _defense;
    protected float _speed;
    protected GameObject _modelUse;
    protected UnitType _type;

    public void Awake()
    {
        this._tileType = TileType.Unit;
        this._crossable = false;
    }

    public override void Initialize()
    {
        UnitTileDefinition _def = (UnitTileDefinition) _definition;
        this._attack = _def._attack;
        this._defense = _def._defense;
        this._speed = _def._speed;
        this._name = _def._name;
        this._type = _def._unitType;
    }

    public float Health { get { return _health; } }
    public float Attack { get { return _attack; } }
    public float Defense { get { return _defense; } }
    public float Speed { get { return _speed; } }

    public abstract void Start();
    public abstract void Update();
}