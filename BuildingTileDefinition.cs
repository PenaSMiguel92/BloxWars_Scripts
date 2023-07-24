using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingTile", menuName = "TileType/BuildingTileDefinition")]

public class BuildingTileDefinition : ScriptableObject
{
    public GameObject _modelUse;
    public string _name;
    public BuildingType _buildingType;
    public float _attack;
    public float _defense;
    public string _structure = "1,1,0,1,1,0,0,0,0";
}
