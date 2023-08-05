using UnityEngine;
public struct TileInfo
{
    public TileInfo(bool crossable, bool constructable, TileType type, Vector2Int position)
    {
        Crossable = crossable;
        Constructable = constructable;
        Type = type;
        Position = position;
        HashKey = position.x.ToString() + "," + position.y.ToString();
    }

    public bool Crossable { get; }
    public bool Constructable { get; }
    public TileType Type { get; }
    public Vector2Int Position { get; }
    public string HashKey { get; }
}