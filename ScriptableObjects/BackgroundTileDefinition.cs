using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundTile", menuName = "TileType/BackgroundTileDefinition")]
public class BackgroundTileDefinition : BaseTileDefinition
{
    public bool Crossable; //whether or not a land unit can cross this tile, i.e, canyon/rock tile.
    public bool Constructable; //whether or not a slab can be built on this tile
    public bool Resource;
    public float ResourceAmount;
}
