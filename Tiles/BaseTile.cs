using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType {Background, Building, Unit}

public abstract class BaseTile : MonoBehaviour
{
    protected bool _crossable;
    protected TileType _tileType;
    protected Vector2Int _localPosition;
    protected Vector3 _worldPosition;
    protected BaseTileDefinition _definition;
    protected Vector2Int _structure;
    protected const int _tileSize = 2;
    public abstract void Initialize();
    public List<TileInfo> GetRelativeTileInfo(TileType type)
    {
        List<TileInfo> _tileInfos = new List<TileInfo>();
        int _width = this._structure.x * _tileSize;
        int _height = this._structure.y * _tileSize;
        for (int _index = 0; _index < _width * _height; _index++)
        {
            int _x = _localPosition.x + (_index % _width);
            int _y = _localPosition.y + (_index / _width);

            TileInfo _newInfo = new TileInfo(false, false, type, new Vector2Int(_x, _y));
            _tileInfos.Add(_newInfo);
        }

        return _tileInfos;
    }
    public bool Crossable {get { return _crossable; } }
    public Vector2Int LocalPosition { get { return _localPosition; } }
    public Vector3 WorldPosition { get { return _worldPosition; } }
    public BaseTileDefinition Definition {get { return _definition; } set { _definition = value; } }

}
