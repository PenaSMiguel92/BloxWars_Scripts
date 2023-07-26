
public struct TileInfo
{
    public TileInfo(bool crossable, bool constructable, TileType type)
    {
        Crossable = crossable;
        Constructable = constructable;
        Type = type;
    }

    public bool Crossable { get; }
    public bool Constructable { get; }
    public TileType Type { get; }
}