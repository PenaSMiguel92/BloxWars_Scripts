using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapGeneration
{
    private static BackgroundTileDefinition[] _tiles;
    private static Vector2 _offset = new Vector2(5,5);
    private static float _scale = 10f;
    private static Vector2 _mapSize;
    private static Vector2 _mapTileSize;
    private static float[] _thresholds = {0.05f, 0.20f, 0.55f, 0.9f, 1f}; //double resource - 5%, resource - 15%, sand - 35% chance, stone - 30% chance, cliff - 10% chance 
    private static bool _loadMap = false;
    private static string _filename = "Map01";

    public static Tile[,] GenerateMap(){
        //Debug.Log("Map Generation begin");
        Tile[,] _map = new Tile[(int)_mapSize.x, (int)_mapSize.y];
        if (!_loadMap){
            for (int x = 0; x < _mapSize.x; x++){
                for (int y = 0; y < _mapSize.y; y++){
                    float _rndVal = Mathf.Clamp(Mathf.PerlinNoise(_offset.x + x / _mapSize.x * _scale, _offset.y + y / _mapSize.y * _scale), 0, 1);
                    int _action = 0;
                    foreach (float _threshold in _thresholds) {
                        Debug.Log(_threshold);
                        if (_rndVal < _threshold){
                            break;
                        }
                        _action++;
                    }
                    BackgroundTileDefinition _tileUse = _tiles[_action];

                    _map[x, y] = new Tile(new Vector2(x, y), _tileUse);
                }
            }
        }
        return _map;
    }

    public static BackgroundTileDefinition[] Tiles {
        get {
            return _tiles;
        }
        set {
            _tiles = value;
        }
    }
    public static Vector2 MapSize {
        get {
            return _mapSize;
        }
        set {
            _mapSize = value;
        }
    }
    public static Vector2 MapTileSize {
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
