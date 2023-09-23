using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitService
{
    private static BaseTileDefinition[] tiles;
    public static bool SpawnUnitAt(Vector2Int position, Player owner, UnitType unitType)
    {
        UnitTileDefinition _unitDefinition = (UnitTileDefinition)tiles[(int)unitType];
        List<TileInfo> _tileInfos = MainMap.GetRelativePositions(position, _unitDefinition, TileType.Unit);
        if (!MainMap.CheckPositions(_tileInfos, TileType.Unit))
            return false;
        Vector2Int minCorner = new(int.MaxValue, int.MaxValue);
        Vector2Int maxCorner = new(int.MinValue, int.MinValue);
        List<string> keys = new();
        foreach (TileInfo tileInfo in _tileInfos)
        {
            Vector2Int tileInfoPos = tileInfo.Position;
            string _strKey =  tileInfoPos.x.ToString() + "," +  tileInfoPos.y.ToString();
            keys.Add(_strKey);
            minCorner = new Vector2Int(Math.Min(minCorner.x, tileInfoPos.x), Math.Min(minCorner.y, tileInfoPos.y));
            maxCorner = new Vector2Int(Math.Max(maxCorner.x, tileInfoPos.x), Math.Max(maxCorner.y, tileInfoPos.y));
        }
        Vector3 _unitLocation = MainMap.LocalToWorldPosition((maxCorner + minCorner)/2);
        BaseUnitTile _unitTile = UnitFactory.BuildUnit(_unitDefinition, _unitLocation, owner);

        foreach (string strKey in keys)
        {
            owner.Units.Add(strKey, _unitTile);
            MainMap.AddUnitToMap(strKey, _unitTile);
        }
       
        return true;
    }

    public static BaseUnitTile[] GetUnits(int plrIndex)
    {
        throw new NotImplementedException();
    }

    public static BaseUnitTile[] GetUnits(int plrIndex, Vector2Int startPos, Vector2Int endPos)
    {
        throw new NotImplementedException();
    }

    public static BaseUnitTile GetUnits(int plrIndex, Vector2Int position)
    {
        throw new NotImplementedException();
    }

    public static BaseTileDefinition[] Tiles 
    {
        get {
            return tiles;
        }
        set {
            tiles = value;
        }
    }

}