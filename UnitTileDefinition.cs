using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitTile", menuName = "TileType/UnitTileDefinition")]

public class UnitTileDefinition : ScriptableObject
{
    public GameObject ModelUse;
    public string Name;
    public float Attack;
    public float Defense;
    public float Speed;
    public string Structure = "0,0,0,0,1,0,0,0,0";
}
