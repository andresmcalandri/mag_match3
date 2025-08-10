using MAG_GameLibraries.Documentation;
using MAG_GameLibraries.Simulation.Tile;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    [CustomerFacing]
    public interface ITileMatchingMode : IGameMode
    {
        ITile?[,] GetCurrentTiles();
        MatchingResult Match();
        MatchingResult Match(int x, int y);
        MatchingResult SwapTiles(Vector2Int pos1, Vector2Int pos2);
    }
}
