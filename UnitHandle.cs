using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitHandle
{
    static BaseTileDefinition[] _tiles;
    // public static bool SpawnUnitAt(Vector2 position, Player owner, UnitType unitType)
    // {
    //     UnitTileDefinition _unitDefinition = (UnitTileDefinition)_tiles[(int)unitType];
    //     Vector2[] _relPositions = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
    //     List<Vector2> _absPositions = new List<Vector2>();
    //     foreach (Vector2 _relPos in _relPositions)
    //     {
    //         Vector2 _newPos = position + _relPos;
    //         _absPositions.Add(_newPos);
    //     }
    //     if (MainMap.CheckPosition(_absPositions, TileType.Unit))
    //     {
    //         //owner.Units.Add()
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

    public static BaseUnitTile[] GetUnits(int plrIndex)
    {
        throw new NotImplementedException();
    }

    public static BaseUnitTile[] GetUnits(int plrIndex, Vector2 startPos, Vector2 endPos)
    {
        throw new NotImplementedException();
    }

    public static BaseUnitTile GetUnits(int plrIndex, Vector2 position)
    {
        throw new NotImplementedException();
    }

    public static BaseTileDefinition[] Tiles 
    {
        get {
            return _tiles;
        }
        set {
            _tiles = value;
        }
    }

}