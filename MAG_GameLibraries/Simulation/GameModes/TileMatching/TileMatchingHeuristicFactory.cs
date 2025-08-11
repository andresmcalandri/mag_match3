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

                case TileMatchingHeuristicType.AnyContiguous:
                    return new AnyContiguousTileMatchingHeuristic();

                default:
                    throw new ArgumentException($"Unsuported Tile Matching Heuristic {tileMatchingHeuristicType}", nameof(tileMatchingHeuristicType));
            }
        }
    }
}