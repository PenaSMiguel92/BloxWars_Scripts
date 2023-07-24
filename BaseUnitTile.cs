using System;
using System.Collections;
using UnityEngine;

public enum UnitType {CarryAll, Gunman, Harvester, HeavyInfantry, Infantry, Launcher, Missiler, MCV, Quad, SiegeTank, Tank, Trike}
public interface IUnitTile
{
    public void LookAt(Vector2 position);
    public void MoveTo(Vector2 position);

    public float Health { get; }
    public float Attack { get; }
    public float Defense { get; }
    public float Speed { get; }
    public Vector2 LocalPosition { get; }
}

public abstract class BaseUnitTile : MonoBehaviour, IUnitTile 
{
    protected string _structure;
    protected string _name;
    protected float _health = 1;
    protected float _attack;
    protected float _defense;
    protected float _speed;
    
    protected Vector2 _localPosition;
    protected GameObject _modelUse;

    public BaseUnitTile(Vector2 position, UnitTileDefinition def){
        this._localPosition = position;
        this._attack = def._attack;
        this._defense = def._defense;
        this._speed = def._speed;
        this._modelUse = def._modelUse;
        this._name = def._name;
    }


    public float Health { get { return _health; } }
    public float Attack { get { return _attack; } }
    public float Defense { get { return _defense; } }
    public float Speed { get { return _speed; } }
    public Vector2 LocalPosition { get { return _localPosition; } }


    public abstract void Awake();
    public abstract void Start();
    public abstract void Update();
    public abstract void MoveTo(Vector2 position);
    public abstract void LookAt(Vector2 position);
}