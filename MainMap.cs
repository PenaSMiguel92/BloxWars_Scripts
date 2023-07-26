using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapType { Background, Building, Unit }
public static class MainMap
{
    private static Vector2 _mapSize; //keep a record of map size, reduce need to use .length , since this would be quicker.
    private static Vector2 _mapTileSize; //Reminder, this is the same size as the tile models, works out for positionioning of tiles.
    private static int _objectMapTileScale = 2;
    private static Dictionary<string, BaseTile> _backgroundMap;
    private static Dictionary<string, BaseTile> _buildingMap;
    private static Dictionary<string, BaseTile> _unitMap;
    private static Dictionary<string, TileInfo> _summaryMap;

    public static void InitializeMap(Vector2 mapSize, Vector2 mapTileSize)
    {
        _mapSize = mapSize;
        _mapTileSize = mapTileSize;
        MapGeneration.MapSize = mapSize;
        MapGeneration.MapTileSize = mapTileSize;
        MapGeneration.LoadMap = false;
        _backgroundMap = MapGeneration.GenerateMap();
    }

    public static Vector3 LocalToWorldPosition(Vector2 _localPos)
    {
        Vector3 _worldPos = new Vector3(_localPos.x * MapTileSize.x + (MapTileSize.x/2), 0, _localPos.y * MapTileSize.y + (MapTileSize.y/2));
        return _worldPos;
    }

    public static Vector2 WorldToLocalPosition(Vector3 _worldPos)
    {
        Vector2 _localPos = new Vector2(Mathf.RoundToInt(_worldPos.x / MapTileSize.x), Mathf.RoundToInt(_worldPos.y / MapTileSize.y));
        return _localPos;
    }

    public static Dictionary<string, TileInfo> GenerateSummaryMap()
    {
        Dictionary<string, TileInfo> _summary = new Dictionary<string, TileInfo>();
        for (int _index = 0; _index < _mapSize.x * _mapSize.y; _index++)
        {
            int x = _index % (int) _mapSize.x;
            int y = _index / (int) _mapSize.x;
            int xScaled = x / _objectMapTileScale;
            int yScaled = y / _objectMapTileScale;

            string _strKey = x.ToString() + "," + y.ToString();
            string _scaledStrKey = xScaled.ToString() + "," + yScaled.ToString();
            BaseTile _backgroundValue;
            if (!_summary.ContainsKey(_strKey))
            {
                TileInfo _tileUse = new TileInfo(true, true, TileType.Background);
                if (_unitMap.ContainsKey(_scaledStrKey))
                {
                    _tileUse = new TileInfo(false, false, TileType.Unit);
                }
                else if (_buildingMap.ContainsKey(_scaledStrKey))
                {
                    _tileUse = new TileInfo(false, false, TileType.Building);
                }
                else if (_backgroundMap.TryGetValue(_strKey, out _backgroundValue))
                {
                    BackgroundTile _bgValueConv = (BackgroundTile) _backgroundValue;
                    _tileUse = new TileInfo(_bgValueConv.Crossable, _bgValueConv.Constructable, TileType.Background);
                }
                _summary.Add(_strKey, _tileUse);
            }
        }

        return _summary;
    }

    public static bool CheckPosition(List<Vector2> positions, TileType type)
    {
        _summaryMap = GenerateSummaryMap();
        int _availableCount = 0;
        foreach (Vector2 pos in positions)
        {
            string _strKey = pos.x.ToString() + "," + pos.y.ToString();
            TileInfo _value;
            if (_summaryMap.TryGetValue(_strKey, out _value))
            {
                if (_value.Type != TileType.Background) continue;
                switch(type)
                {
                    case TileType.Building:
                        if (_value.Constructable)
                        {
                            _availableCount++;
                        }
                        break;
                    case TileType.Unit:
                        if (_value.Crossable)
                        {
                            _availableCount++;
                        }
                        break;
                }
            }
        }
        return (_availableCount == positions.Count);
    }
    
    public static Vector2 MapSize
    {
        get {
            return _mapSize;
        }
        set {
            _mapSize = value;
        }
    }
    public static Vector2 MapTileSize
    {
        get {
            return _mapTileSize;
        }
        set {
            _mapTileSize = value;
        }
    }

    public static Dictionary<string, TileInfo> SummaryMap 
    {
        get {
            _summaryMap = GenerateSummaryMap();
            return _summaryMap;
        }
        set {
            _summaryMap = value;
        }
    }
}
