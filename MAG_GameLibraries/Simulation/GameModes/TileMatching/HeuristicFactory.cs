using System;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal class HeuristicFactory : ITileMatchingHeuristicFactory
    {

        public ITileMatchingHeuristic Create(Type tileMatchingHeuristicType)
        {
            return new DefaultTileMatchingHeuristic();
        }
    }
}