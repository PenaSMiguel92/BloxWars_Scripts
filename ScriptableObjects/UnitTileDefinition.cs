using UnityEngine;

[CreateAssetMenu(fileName = "UnitTile", menuName = "TileType/UnitTileDefinition")]

public class UnitTileDefinition : BaseTileDefinition
{
    public UnitType _unitType;
    public float _attack;
    public float _defense;
    public float _speed;
    
}
