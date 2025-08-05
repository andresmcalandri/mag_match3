using System;
using System.Collections.Generic;
using System.Text;

namespace MAG_GameLibraries.Simulation.Tile
{
    public interface ITile
    {
        int Id { get; }
        ITileType TileType { get; }
        object? Metadata { get; }
    }
}
