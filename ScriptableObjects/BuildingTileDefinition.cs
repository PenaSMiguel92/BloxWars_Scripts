using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingTile", menuName = "TileType/BuildingTileDefinition")]

public class BuildingTileDefinition : BaseTileDefinition
{
    public BuildingType _buildingType;
    public float _attack;
    public float _defense;
}
