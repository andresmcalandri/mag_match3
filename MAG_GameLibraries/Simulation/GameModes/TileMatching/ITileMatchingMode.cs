using MAG_GameLibraries.Simulation.Tile;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    public interface ITileMatchingMode : IGameMode
    {
        ITile?[,] GetCurrentTiles();
        MatchingResult Match();
        MatchingResult Match(int x, int y);
    }
}
