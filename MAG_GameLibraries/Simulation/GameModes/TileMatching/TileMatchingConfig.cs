using MAG_GameLibraries.Documentation;
using MAG_GameLibraries.Simulation.Board;
using System;
using System.Numerics;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    [CustomerFacing]
    public interface ITileMatchingConfig
    {
        Type TileMatchingHeuristic { get; }
        TileBoardConfig BoardConfig { get; }
        int MatchingNumber { get; }
    }
}
