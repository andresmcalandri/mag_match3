using System;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal interface ITileMatchingHeuristicFactory
    {
        ITileMatchingHeuristic Create(TileMatchingHeuristicType tileMatchingHeuristicType);
    }
}