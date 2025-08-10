
using MAG_GameLibraries.Documentation;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Tile
{
    [CustomerFacing]
    public interface ITile
    {
        ulong Id { get; }
        string TileId { get; }
        Vector2Int Position { get; }
        object? Metadata { get; }
    }
}
