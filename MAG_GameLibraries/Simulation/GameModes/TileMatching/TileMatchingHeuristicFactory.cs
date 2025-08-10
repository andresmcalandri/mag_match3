using System;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal class TileMatchingHeuristicFactory : ITileMatchingHeuristicFactory
    {
        public ITileMatchingHeuristic Create(TileMatchingHeuristicType tileMatchingHeuristicType)
        {
            switch (tileMatchingHeuristicType)
            {
                case TileMatchingHeuristicType.Default:
                    return new DefaultTileMatchingHeuristic();

                default:
                    throw new ArgumentException($"Unsuported Tile Matching Heuristic {tileMatchingHeuristicType}", nameof(tileMatchingHeuristicType));
            }
        }
    }
}