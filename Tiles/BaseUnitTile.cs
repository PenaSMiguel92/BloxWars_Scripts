using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType {CarryAll, Gunman, Harvester, Infantry, HeavyInfantry, Launcher, Missiler, MCV, Quad, SiegeTank, Trike, Tank}
public interface IUnitTile
{
    public float Health { get; }
    public float Attack { get; }
    public float Defense { get; }
    public float Speed { get; }
    public Vector2Int LocalPosition { get; }
    public Player Owner { get; set; }
    public bool Selected { get; set; }
}

public abstract class BaseUnitTile : BaseTile, IUnitTile 
{
    
    protected Transform _transform;
    protected string _name;
    protected float _health = 1;
    protected float _attack;
    protected float _defense;
    protected float _speed;
    protected GameObject _modelUse;
    protected UnitType _type;
    protected bool selected;
    protected Player owner;
    protected Queue<Command> commands;
    protected Coroutine commandCoroutine;
    protected bool coroutineRunning = false;

    public override void Initialize()
    {
        
        UnitTileDefinition _def = (UnitTileDefinition) _definition;
        _attack = _def._attack;
        _defense = _def._defense;
        _speed = _def._speed;
        _name = _def._name;
        _type = _def._unitType;
        _structure = _def._structure;
        _tileType = TileType.Unit;
        _crossable = false;
        _transform = gameObject.GetComponent<Transform>();
        _localPosition = MainMap.WorldToLocalPosition(_transform.localPosition);
        Vector3 _offset = new Vector3((float)(_structure.x / 2f), 0, (float)(_structure.x / 2f));
        _transform.localPosition += _offset;
    }

    public void Select(Player player) {
        if (!player.Equals(owner))
            return;

        selected = true;
        Debug.Log("Selected Unit At Location: (" + _localPosition.x + "," + _localPosition.y + ")");
    }

    public void SendCommand(Command cmd) {
        commands.Enqueue(cmd);
    }

    public void ExecuteCommands() {
        if (commands.Count <= 0)
            return;
        if (coroutineRunning)
            return;

        if (commands.TryDequeue(out Command cmd)) {
            cmd.IssueOrders(this);
            commandCoroutine = StartCoroutine(cmd.ExecuteOrders());
        }
    }

    public float Health { get { return _health; } }
    public float Attack { get { return _attack; } }
    public float Defense { get { return _defense; } }
    public float Speed { get { return _speed; } }
    public Player Owner {get { return owner; } set { owner = value; }}
    public bool Selected {get { return selected; } set { selected = value; }}

    public bool CoroutineRunning {get { return coroutineRunning; } set { coroutineRunning = value; }}
    //public abstract void Start();
    //public abstract void Update();
}