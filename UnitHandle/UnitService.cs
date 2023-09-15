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
        
        Vector3 _unitLocation = MainMap.LocalToWorldPosition(position);
        BaseUnitTile _unitTile = UnitFactory.BuildUnit(_unitDefinition, _unitLocation, owner);
        string _strKey = position.x.ToString() + "," + position.y.ToString();
        owner.Units.Add(_strKey, _unitTile);
        MainMap.AddUnitToMap(_strKey, _unitTile);
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