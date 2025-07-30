public struct TileData
{
    public ITileType Type;
    public int Index;

    public TileData(ITileType type, int index)
    {
        this.Type = type;
        this.Index = index;
    }
}
