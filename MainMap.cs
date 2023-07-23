using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainMap
{
    private static Vector2 _mapSize; //keep a record of map size, reduce need to use .length , since this would be quicker.
    private static Vector2 _mapTileSize; //Reminder, this is the same size as the tile models, works out for positionioning of tiles.
    
    private static Tile[,] _map;
    public static void InitializeMap(Vector2 mapSize, Vector2 mapTileSize){
        //Debug.Log("Map Initializing");
        _mapSize = mapSize;
        _mapTileSize = mapTileSize;
        MapGeneration.MapSize = mapSize;
        MapGeneration.MapTileSize = mapTileSize;
        MapGeneration.LoadMap = false;

        _map = MapGeneration.GenerateMap();
        for (int x = 0; x < _mapSize.x; x++){
            for (int y = 0; y < _mapSize.y; y++){
                Tile _curTile = _map[x, y];
                _curTile.DrawSelf();
            }
        }
    }

    public static Vector3 LocalToWorldPosition(Vector2 _localPos){
        Vector3 _worldPos = new Vector3(_localPos.x * MapTileSize.x + (MapTileSize.x/2), 0, _localPos.y * MapTileSize.y + (MapTileSize.y/2));
        return _worldPos;
    }

    public static Vector2 WorldToLocalPosition(Vector3 _worldPos){
        Vector2 _localPos = new Vector2(Mathf.RoundToInt(_worldPos.x / MapTileSize.x), Mathf.RoundToInt(_worldPos.y / MapTileSize.y));
        return _localPos;
    }
    
    public static Vector2 MapSize{
        get {
            return _mapSize;
        }
        set {
            _mapSize = value;
        }
    }
    public static Vector2 MapTileSize{
        get {
            return _mapTileSize;
        }
        set {
            _mapTileSize = value;
        }
    }
}
