using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.GameModes.TileMatching;

namespace MAG_GameLibraries.Simulation.GameModes
{
    internal class GameModeFactory : IGameModeFactory
    {
        private readonly ITileBoardFactory _tileBoardFactory;
        private readonly ITileMatchingHeuristicFactory _tileMatchingHeuristicFactory;

        public GameModeFactory(
            ITileBoardFactory tileBoardFactory, 
            ITileMatchingHeuristicFactory tileMatchingHeuristicFactory) 
        {
            _tileBoardFactory = tileBoardFactory;
            _tileMatchingHeuristicFactory = tileMatchingHeuristicFactory;
        }

        public GameModeResult Create(IGameConfig gameConfig)
        {
            switch (gameConfig)
            {
                case TileMatchingConfig tileMatchingConfig:
                {
                    if (tileMatchingConfig.BoardConfig is null)
                        return new GameModeResult(new Error("BoardConfig can't be null"));

                    var board = _tileBoardFactory.CreateBoard(tileMatchingConfig.BoardConfig);
                    var heuristic = _tileMatchingHeuristicFactory.Create(tileMatchingConfig.TileMatchingHeuristic);
                    var gameMode = new BaseTileMatchingMode(tileMatchingConfig, board, heuristic);
                    return new GameModeResult(gameMode);
                }

                default:
                    return new GameModeResult(new Error($"There is no factory implementation for the provided config {gameConfig}"));
            }
        }
    }
}
