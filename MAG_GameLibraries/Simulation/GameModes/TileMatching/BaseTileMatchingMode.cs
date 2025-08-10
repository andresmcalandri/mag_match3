using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.Tile;
using System.Collections.Generic;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal class BaseTileMatchingMode : ITileMatchingMode
    {
        private readonly TileMatchingConfig _config;
        private readonly ITileBoard _board;
        private readonly ITileMatchingHeuristic _matchingHeuristic;

        public BaseTileMatchingMode(TileMatchingConfig config, ITileBoard board, ITileMatchingHeuristic tileMatchingHeuristic)
        {
            _config = config;
            _board = board;
            _matchingHeuristic = tileMatchingHeuristic;
        }

        public Result Initialize()
        {
            if (_config.BoardConfig!.StartingTiles is not null)
                _board.Initialize(_config.BoardConfig.StartingTiles, IsStartingTileValid);
            else
                _board.Initialize(IsStartingTileValid);
            
            return Result.Success;
        }

        private bool IsStartingTileValid(TileType newTileType, Vector2Int position)
        {
            return !_matchingHeuristic.WouldMatch(_board, newTileType, position.x, position.y, _config.MatchingNumber);
        }

        public ITile?[,] GetCurrentTiles()
        {
            return _board.GetAllTiles();
        }

        public MatchingResult Match()
        {
            var matchedTiles = new List<ITile>();

            for (var y = 0; y < _board.BoardSize.y; y++)
            {
                for (var x = 0; x < _board.BoardSize.x; x++)
                {
                    var tile = _board.GetTile(x, y);
                    if (tile is null)
                        continue;

                    ITile[] currentMatchedTiles = _matchingHeuristic.Match(_board, x, y, _config.MatchingNumber);
                    matchedTiles.AddRange(currentMatchedTiles);
                }
            }

            return new MatchingResult(matchedTiles.ToArray(), RefillBoard());
        }

        public MatchingResult Match(int x, int y)
        {
            var matchedTiles = _matchingHeuristic.Match(_board, x, y, _config.MatchingNumber);
            if(matchedTiles is null)
                return new MatchingResult();
            
            return new MatchingResult(matchedTiles, RefillBoard());
        }

        private RefillResult RefillBoard()
        { 
            var refilledTiles = _board.RefillBoard();
            return new RefillResult(refilledTiles, _config.MatchOnRefill ? Match() : null);
        }
    }
}
