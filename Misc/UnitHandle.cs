using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitHandle
{
    private static BaseTileDefinition[] tiles;
    public static bool SpawnUnitAt(Vector2Int position, Player owner, UnitType unitType)
    {
        UnitTileDefinition _unitDefinition = (UnitTileDefinition)tiles[(int)unitType];
        List<TileInfo> _tileInfos = MainMap.GetRelativePositions(position, _unitDefinition, TileType.Unit);
        if (MainMap.CheckPositions(_tileInfos, TileType.Unit))
        {
            Vector3 _unitLocation = MainMap.LocalToWorldPosition(position);
            GameObject _unitObj = GameObject.Instantiate(_unitDefinition._modelUse, _unitLocation, new Quaternion());
            BaseUnitTile _unitTile = _unitObj.GetComponent<BaseUnitTile>();
            _unitTile.Definition = _unitDefinition;
            _unitTile.Initialize();
            string _strKey = position.x.ToString() + "," + position.y.ToString();
            owner.Units.Add(_strKey, _unitTile);
            return true;
        }
        else
        {
        return false;
        }
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