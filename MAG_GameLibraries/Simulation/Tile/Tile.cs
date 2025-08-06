namespace MAG_GameLibraries.Simulation.Tile
{
    public readonly struct Tile : ITile
    {
        public TileType Type { get; }
        public int Id { get; }
        public object? Metadata { get; }

        public Tile(TileType type, int id, object? metadata)
        {
            Type = type;
            Id = id;
            Metadata = metadata;
        }
    }
}