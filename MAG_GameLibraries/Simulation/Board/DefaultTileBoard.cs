using MAG_GameLibraries.Extensions;
using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.Tile;
using System;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Board
{
    public class DefaultTileBoard : ITileBoard
    {
        public Vector2Int BoardSize { get; }

        private ITile[,] _activeTiles;
        private TileType[] _supportedTiles;
        private ITileFactory _tileFactory;

        internal DefaultTileBoard(Vector2Int boardSize, ITileFactory tileFactory, TileType[] supportedTiles) 
        { 
            BoardSize = boardSize;
            _activeTiles = new ITile[BoardSize.x, BoardSize.y];

            _tileFactory = tileFactory;
            _supportedTiles = supportedTiles;
        }

        public Result Initialize(Func<TileType, bool>? tileValidator = null)
        {
            for (int x = 0; x < BoardSize.x; x++)
            {
                for (int y = 0; y < BoardSize.y; y++)
                {
                    var newTile = GenerateRandomTile(tileValidator) ?? throw new InvalidOperationException("Couldn't generate a valid");
                    _activeTiles[x, y] = newTile;
                }
            }

            return Result.Success;
        }

        public Result Initialize(TileType[,] startingTiles, Func<TileType, bool>? tileValidator = null)
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
                        var newTile = GenerateRandomTile(tileValidator) ?? throw new InvalidOperationException("Couldn't generate a valid");
                        _activeTiles[x, y] = newTile;

                        continue;
                    }

                    _activeTiles[x, y] = _tileFactory.Create(startingTiles[x, y]);
                }
            }

            return Result.Success;
        }

        public ITile GetTile(int x, int y)
        {
            return _activeTiles[x, y];
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < BoardSize.x && y >= 0 && y < BoardSize.y;
        }

        public void RefillBoard()
        {
            throw new System.NotImplementedException();
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

            /*
            // TODO Update tile positions?
            if (CurrentTiles[pos1.x, pos1.y] != null)
                CurrentTiles[pos1.x, pos1.y].Position = pos1;
            if (CurrentTiles[pos2.x, pos2.y] != null)
                CurrentTiles[pos2.x, pos2.y].Position = pos2;
            */
        }

        protected virtual ITile? GenerateRandomTile(Func<TileType, bool>? tileValidator = null)
        {
            var checkedTileTypes = _supportedTiles.Shuffle().ToStack();

            while (checkedTileTypes.Count > 0)
            {
                var newTileType = checkedTileTypes.Pop();

                // If the tile is not valid we continue
                if (!tileValidator?.Invoke(newTileType) ?? false)
                    continue;

                return _tileFactory.Create(newTileType); // TODO Add position to tile?
            }

            return null;
        }
    }
}