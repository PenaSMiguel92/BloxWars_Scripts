using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingTile", menuName = "TileType/BuildingTileDefinition")]

public class BuildingTileDefinition : ScriptableObject
{
    public GameObject ModelUse;
    public string Name;
    public float Attack;
    public float Defense;
    public string Structure = "1,1,0,1,1,0,0,0,0";
}
