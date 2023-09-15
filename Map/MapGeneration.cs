using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapGeneration
{
    
    private static BaseTileDefinition[] _tiles;
    private static Vector2 _offset = new(Random.value * 50, Random.value * 50);
    private static readonly float _scale = 15f;
    private static Vector2Int _mapSize;
    private static Vector2Int _mapTileSize;
    private static float[] _thresholds = {0.05f, 0.20f, 0.55f, 0.9f, 1f}; //double resource - 5%, resource - 15%, sand - 35% chance, stone - 30% chance, cliff - 10% chance 
    private static bool _loadMap = false;
    private static string _filename = "Map01";

    public static Dictionary<string, BaseTile> GenerateMap()
    {
        Dictionary<string, BaseTile> _map = new Dictionary<string, BaseTile>();
        if (!_loadMap)
        {
            for (int index = 0; index < _mapSize.x * _mapSize.y; index++)
            {
                int x = index % _mapSize.x;
                int y = index / _mapSize.x;

                float _rndVal = Mathf.Clamp(Mathf.PerlinNoise(_offset.x + x / (float)_mapSize.x * _scale, _offset.y + y / (float)_mapSize.x * _scale), 0, 1);
                int _action = 0;
                foreach (float _threshold in _thresholds) {
                    if (_rndVal <= _threshold){
                        break;
                    }
                    _action++;
                }
                BaseTileDefinition _tileUse = _tiles[_action];

                string _key = x.ToString() + "," + y.ToString();
                if (!_map.ContainsKey(_key))
                {
                    Vector2Int _location = new(x, y);
                    GameObject _tileObject = Object.Instantiate(_tileUse._modelUse, MainMap.LocalToWorldPosition(_location), new Quaternion());
                    BaseTile _baseTile = _tileObject.GetComponent<BaseTile>();
                    _baseTile.Definition = _tileUse;
                    _baseTile.Initialize();
                    _map.Add(_key, _baseTile);
                }
            }
        }
        return _map;
    }

    public static BaseTileDefinition[] Tiles {
        get {
            return _tiles;
        }
        set {
            _tiles = value;
        }
    }
    public static Vector2Int MapSize {
        get {
            return _mapSize;
        }
        set {
            _mapSize = value;
        }
    }
    public static Vector2Int MapTileSize {
        get {
            return _mapTileSize;
        }
        set {
            _mapTileSize = value;
        }
    }

    public static bool LoadMap {
        get {
            return _loadMap;
        }
        set {
            _loadMap = value;
        }
    }

    public static string FileName{
        get {
            return _filename;
        }
        set {
            _filename = value;
        }
    }

    public static float[] Thresholds{
        get {
            return _thresholds;
        }
        set {
            _thresholds = value;
        }
    }
}
