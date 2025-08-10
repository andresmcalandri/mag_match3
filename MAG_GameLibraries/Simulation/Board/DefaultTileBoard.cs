using MAG_GameLibraries.Extensions;
using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.Tile;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Board
{
    public class DefaultTileBoard : ITileBoard
    {
        public Vector2Int BoardSize { get; }

        private readonly ITile?[,] _activeTiles;
        private readonly TileType[] _supportedTiles;
        private readonly ITileFactory _tileFactory;

        internal DefaultTileBoard(Vector2Int boardSize, ITileFactory tileFactory, TileType[] supportedTiles)
        {
            BoardSize = boardSize;
            _activeTiles = new ITile[BoardSize.x, BoardSize.y];

            _tileFactory = tileFactory;

            if (supportedTiles.Length == 0)
                throw new ArgumentException("The supported tile list provided can't be empty", nameof(supportedTiles));

            _supportedTiles = supportedTiles;
        }

        public Result Initialize(Func<TileType, Vector2Int, bool>? tileValidator = null)
        {
            for (int x = 0; x < BoardSize.x; x++)
            {
                for (int y = 0; y < BoardSize.y; y++)
                {
                    var newTile = GenerateRandomTile(x, y, tileValidator) ?? throw new InvalidOperationException($"Couldn't generate a valid tile for position {x}, {y}");
                    _activeTiles[x, y] = newTile;
                }
            }

            return Result.Success;
        }

        public Result Initialize(TileType[,] startingTiles, Func<TileType, Vector2Int, bool>? tileValidator = null)
        {
            var width = startingTiles.GetLength(0);
            var height = startingTiles.GetLength(1);

            if (width > BoardSize.x)
                throw new ArgumentException("The Starting tile set width is longer than the board configuration", nameof(startingTiles));

            if (height > BoardSize.y)
                throw new ArgumentException("The Starting tile set height is longer than the board configuration", nameof(startingTiles));

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (startingTiles[x, y] is null)
                    {
                        var newTile = GenerateRandomTile(x, y, tileValidator) ?? throw new InvalidOperationException($"Couldn't generate a valid tile for position {x}, {y}");
                        _activeTiles[x, y] = newTile;

                        continue;
                    }

                    _activeTiles[x, y] = _tileFactory.Create(startingTiles[x, y], new Vector2Int(x, y));
                }
            }

            return Result.Success;
        }

        public ITile? GetTile(int x, int y)
        { 
            return _activeTiles[x, y];
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < BoardSize.x && y >= 0 && y < BoardSize.y;
        }

        //TODO Could include refill strat with limits and such
        public Stack<ITile>[] RefillBoard()
        {
            var newTiles = new Stack<ITile>[BoardSize.x];

            // Drop existing tiles down and fill empty spaces
            for (int x = 0; x < BoardSize.x; x++)
            {
                CompactColumn(x);
                if(_supportedTiles.Length > 0)
                    newTiles[x] = FillEmptySpaces(x);
            }

            return newTiles;
        }

        public void SetTile(int x, int y, ITile tile)
        {
            if (!IsValidPosition(x, y))
                throw new ArgumentException($"Poisition {x},{y} is invalid");

            _activeTiles[x, y] = tile;
        }

        public void SwapTiles(Vector2Int pos1, Vector2Int pos2)
        {
            if (!IsValidPosition(pos1.x, pos1.y))
                throw new ArgumentException("Poisition is invalid", nameof(pos1));

            if (!IsValidPosition(pos2.x, pos2.y))
                throw new ArgumentException("Poisition is invalid", nameof(pos2));

            var temp = _activeTiles[pos1.x, pos1.y];
            _activeTiles[pos1.x, pos1.y] = _activeTiles[pos2.x, pos2.y];
            _activeTiles[pos2.x, pos2.y] = temp;

            // TODO Update tile positions?
        }

        // TODO This could be a TryGen with an out instead since it can fail
        protected virtual ITile? GenerateRandomTile(int x, int y, Func<TileType, Vector2Int, bool>? tileValidator = null)
        {
            if(_supportedTiles.Length == 0)
                return null;

            var position = new Vector2Int(x, y);
            if (tileValidator == null)
            {
                var random = new System.Random();
                var randomTileType = _supportedTiles[random.Next(0, _supportedTiles.Length)];
                return _tileFactory.Create(randomTileType, position);
            }

            var checkedTileTypes = _supportedTiles.Shuffle().ToStack();

            while (checkedTileTypes.Count > 0)
            {
                var newTileType = checkedTileTypes.Pop();

                // If the tile is not valid we continue
                if (!tileValidator?.Invoke(newTileType, position) ?? false)
                    continue;

                return _tileFactory.Create(newTileType, position);
            }

            return null;
        }

        public ITile?[,] GetAllTiles()
        {
            return (ITile?[,])_activeTiles.Clone();
        }

        //TODO This could be separate for multiple refill strats. IE Refill direction
        #region Refill Strategy
        protected void CompactColumn(int x)
        {
            int writeIndex = 0;
            for (int y = 0; y < BoardSize.y; y++)
            {
                if (_activeTiles[x, y] != null)
                {
                    if (writeIndex != y)
                    {
                        _activeTiles[x, writeIndex] = _activeTiles[x, y];
                        _activeTiles[x, y] = null;
                        //_activeTiles[x, writeIndex].Position = new Vector2Int(x, writeIndex);
                    }
                    writeIndex++;
                }
            }
        }

        protected Stack<ITile> FillEmptySpaces(int x)
        {
            var newTiles = new Stack<ITile>();
            for (int y = 0; y < BoardSize.y; y++)
            {
                if (_activeTiles[x, y] == null)
                {
                    var newTile = GenerateRandomTile(x, y);
                    if (newTile == null)
                        throw new InvalidOperationException($"Couldn't generate new tile while refilling the board position {x}, {y}");

                    _activeTiles[x, y] = newTile;
                    newTiles.Push(newTile);
                }
            }

            return newTiles;
        }

        #endregion
    }
}