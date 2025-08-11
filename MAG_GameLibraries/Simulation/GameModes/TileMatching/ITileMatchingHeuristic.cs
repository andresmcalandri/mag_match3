using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.Tile;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal interface ITileMatchingHeuristic
    {
        /// <summary>
        /// Returns matched tiles if requirement is met
        /// </summary>
        ITile[] Match(ITileBoard board, int x, int y, int matchingRequirement);
        /// <summary>
        /// Returns true if matchingRequirement is met
        /// </summary>
        bool WouldMatch(ITileBoard board, TileType tileType, int x, int y, int matchingRequirement);
    }
}