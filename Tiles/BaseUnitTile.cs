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

// public class DummyUnitPiece : BaseTile, IUnitTile
// {
//     Transform _transform;
//     string _name;
//     bool _origin = false;
//     float _health = 1;
//     protected float _attack;
//     protected float _defense;
//     protected float _speed;
//     BaseBuildingTile _originMainTile;
//     BuildingType _type;
//     protected const int _tileSize = 2; //how many backgroundtiles per structure unit 
//     protected Vector2Int _structureOnMap = new Vector2Int(1, 1); //Options: 1x1, 2x2, 3x2, and 3x3;
//     protected List<DummyUnitPiece> _structure;

//     public void Awake()
//     {
//         this._transform = gameObject.GetComponent<Transform>();
//         this._crossable = false;
//         this._localPosition = MainMap.WorldToLocalPosition(this._transform.localPosition);
//     }
//     public override void Initialize()
//     {
//         BuildingTileDefinition _def = (BuildingTileDefinition) this._definition;
//         this._name = _def._name;
//         this._type = _def._buildingType;
//     }

//     public float Health { get { return _health; } }
//     public float Attack { get { return _attack; } }
//     public float Defense { get { return _defense; } }
//     public float Speed { get { return _speed; } }
//     public bool Origin { get { return _origin; } }
//     public BaseBuildingTile OriginMainTile {get { return _originMainTile; } set { _originMainTile = value; } }
// } 

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

    public override void Initialize()
    {
        
        UnitTileDefinition _def = (UnitTileDefinition) this._definition;
        this._attack = _def._attack;
        this._defense = _def._defense;
        this._speed = _def._speed;
        this._name = _def._name;
        this._type = _def._unitType;
        this._structure = _def._structure;
        this._tileType = TileType.Unit;
        this._crossable = false;
        this._transform = gameObject.GetComponent<Transform>();
        this._localPosition = MainMap.WorldToLocalPosition(_transform.localPosition);
        Vector3 _offset = new Vector3((float)(this._structure.x / 2f), 0, (float)(this._structure.x / 2f));
        this._transform.localPosition = this._transform.localPosition + _offset;
        Debug.Log("Initializing... " + this._type.ToString() + "| Structure: " + this._structure.ToString());
        
    }

    public void Select(Player player) {
        if (!player.Equals(this.owner))
            return;

        this.selected = true;
        Debug.Log("Selected Unit At Location: (" + this._localPosition.x + "," + this._localPosition.y + ")");
    }

    public float Health { get { return _health; } }
    public float Attack { get { return _attack; } }
    public float Defense { get { return _defense; } }
    public float Speed { get { return _speed; } }
    public Player Owner {get { return this.owner; } set { this.owner = value; }}
    public bool Selected {get { return this.selected; } set { this.selected = value; }}
    //public abstract void Start();
    //public abstract void Update();
}