namespace MAG_GameLibraries.Simulation.Tile
{
    public readonly struct Tile : ITile
    {
        public ITileType TileType { get; }
        public int Id { get; }
        public object? Metadata { get; }

        public Tile(ITileType type, int id, object? metadata)
        {
            TileType = type;
            Id = id;
            Metadata = metadata;
        }
    }
}