using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.Tile;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal class BaseTileMatchingMode : IGameMode
    {
        private ITileMatchingConfig _config;
        private ITileBoard _board;
        private ITileMatchingHeuristic _matchingHeuristic;

        public BaseTileMatchingMode(ITileMatchingConfig config, ITileBoard board, ITileMatchingHeuristic tileMatchingHeuristic)
        {
            _config = config;
            _board = board;
            _matchingHeuristic = tileMatchingHeuristic;
        }

        public Result Initialize()
        {
            //_board.Initialize(_config.BoardConfig.StartingTiles);
            return Result.Success;
        }
    }
}
