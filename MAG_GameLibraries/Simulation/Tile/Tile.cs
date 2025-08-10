using System;

namespace MAG_GameLibraries.Simulation.Tile
{
    public readonly struct Tile : ITile
    {
        public string TileId { get; }
        public ulong Id { get; }
        public object? Metadata { get; }

        public Tile(string name, ulong id, object? metadata)
        {
            TileId = name;
            Id = id;
            Metadata = metadata;
        }
    }
}