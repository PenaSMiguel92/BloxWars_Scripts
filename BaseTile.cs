using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType {Background, Building, Unit}

public abstract class BaseTile : MonoBehaviour
{
    protected bool _crossable;
    protected TileType _tileType;
    protected Vector2 _localPosition;
    protected Vector3 _worldPosition;
    protected BaseTileDefinition _definition;

    public abstract void Initialize();
    public bool Crossable {get { return _crossable; } }
    public Vector2 LocalPosition { get { return _localPosition; } }
    public Vector3 WorldPosition { get { return _worldPosition; } }
    public BaseTileDefinition Definition {get { return _definition; } set { _definition = value; } }

}
