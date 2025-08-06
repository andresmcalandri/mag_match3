using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.Tile;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal interface ITileMatchingHeuristic
    {
        ITile[] Match(ITileBoard board, int x, int y, int matchingRequirement);
    }
}