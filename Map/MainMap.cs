using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapType { Background, Building, Unit }
public static class MainMap
{
    private static Vector2Int _mapSize; //keep a record of map size, reduce need to use .length , since this would be quicker.
    private static Vector2Int _mapTileSize; //Reminder, this is the same size as the tile models, works out for positionioning of tiles.
    private static Dictionary<string, BaseTile> _backgroundMap;
    private static Dictionary<string, BaseTile> _buildingMap;
    private static Dictionary<string, BaseTile> _unitMap;
    private static Dictionary<string, TileInfo> _summaryMap;

    public static void InitializeMap(Vector2Int mapSize, Vector2Int mapTileSize)
    {
        _mapSize = mapSize;
        _mapTileSize = mapTileSize;
        MapGeneration.MapSize = mapSize;
        MapGeneration.MapTileSize = mapTileSize;
        MapGeneration.LoadMap = false;
        _backgroundMap = MapGeneration.GenerateMap();
        _buildingMap = new Dictionary<string, BaseTile>();
        _unitMap = new Dictionary<string, BaseTile>();
    }

    public static Vector3 LocalToWorldPosition(Vector2Int localPos)
    {
        Vector3 _worldPos = new Vector3(localPos.x * MapTileSize.x + (MapTileSize.x/2), 0, localPos.y * MapTileSize.y + (MapTileSize.y/2));
        return _worldPos;
    }

    public static Vector2Int WorldToLocalPosition(Vector3 worldPos)
    {
        Vector2Int _localPos = new Vector2Int(Mathf.RoundToInt(worldPos.x / MapTileSize.x), Mathf.RoundToInt(worldPos.z / MapTileSize.y));
        return _localPos;
    }

    public static void GenerateSummaryMap()
    {
        _summaryMap = new Dictionary<string, TileInfo>();
        for (int _index = 0; _index < _mapSize.x * _mapSize.y; _index++)
        {
            int x = _index % (int) _mapSize.x;
            int y = _index / (int) _mapSize.x;
            string _strKey = x.ToString() + "," + y.ToString();
            
            if (!_summaryMap.ContainsKey(_strKey))
            {

                if (_unitMap.ContainsKey(_strKey))
                {
                     BaseTile _unitTile;
                    if (_unitMap.TryGetValue(_strKey, out _unitTile))
                    {
                        AddPositionsToSummaryMap(_unitTile.GetRelativeTileInfo(TileType.Unit));
                        continue;
                    }
                }
                if (_buildingMap.ContainsKey(_strKey))
                {
                    BaseTile _buildingTile;
                    if (_buildingMap.TryGetValue(_strKey, out _buildingTile))
                    {
                        AddPositionsToSummaryMap(_buildingTile.GetRelativeTileInfo(TileType.Building));
                        continue;
                    }
                }

                BaseTile _backgroundValue;
                if (_backgroundMap.TryGetValue(_strKey, out _backgroundValue))
                {
                    BackgroundTile _bgValueConv = (BackgroundTile) _backgroundValue;
                    TileInfo _tileUse = new TileInfo(_bgValueConv.Crossable, _bgValueConv.Constructable, TileType.Background, new Vector2Int(x,y));
                    _summaryMap.Add(_strKey, _tileUse);
                }
                
            }
        }
    }

    public static List<TileInfo> GetRelativePositions(Vector2Int position, BaseTileDefinition definition, TileType type)
    {
        const int _tileSize = 2;
        List<TileInfo> _tileInfos = new List<TileInfo>();
        int _width = definition._structure.x * _tileSize;
        int _height = definition._structure.y * _tileSize;
        for (int _index = 0; _index < _width * _height; _index++)
        {
            int _x = position.x + (_index % _width);
            int _y = position.y + (_index / _width);

            TileInfo _newInfo = new TileInfo(false, false, type, new Vector2Int(_x, _y));
            _tileInfos.Add(_newInfo);
        }

        return _tileInfos;
    }

    private static void AddPositionsToSummaryMap(List<TileInfo> infoTiles)
    {
        foreach(TileInfo _info in infoTiles)
        {
            _summaryMap.Add(_info.HashKey, _info);
        }
    }

    public static bool CheckPositions(List<TileInfo> infoTiles, TileType type)
    {
        GenerateSummaryMap();
        int _availableCount = 0;
        foreach (TileInfo _info in infoTiles)
        {
            TileInfo _value;
            if (_summaryMap.TryGetValue(_info.HashKey, out _value))
            {
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
        return (_availableCount == infoTiles.Count);
    }
    
    public static Vector2Int MapSize
    {
        get {
            return _mapSize;
        }
        set {
            _mapSize = value;
        }
    }
    public static Vector2Int MapTileSize
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
            GenerateSummaryMap();
            return _summaryMap;
        }
        set {
            _summaryMap = value;
        }
    }
}
