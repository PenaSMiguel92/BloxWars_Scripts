using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitTile", menuName = "TileType/UnitTileDefinition")]

public class UnitTileDefinition : ScriptableObject
{
    public GameObject _modelUse;
    public string _name;
    public UnitType _unitType;
    public float _attack;
    public float _defense;
    public float _speed;
}
