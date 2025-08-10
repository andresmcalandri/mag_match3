using System;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Tile
{
    public readonly struct Tile : ITile
    {
        public string TileId { get; }
        public ulong Id { get; }
        public Vector2Int Position { get; }

        public object? Metadata { get; }

        public Tile(string name, ulong id, Vector2Int position, object? metadata)
        {
            TileId = name;
            Id = id;
            Position = position;
            Metadata = metadata;
        }
    }
}