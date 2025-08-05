using MAG_GameLibraries.Documentation;
using MAG_GameLibraries.Simulation.Board;
using System.Numerics;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    [CustomerFacing]
    public interface ITileMatchingConfig
    {
        ITileMatchingHeuristic TileMatchingHeuristic { get; }
        TileBoardConfig BoardConfig { get; }
        int MatchingNumber { get; }
    }
}
