using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.Tile;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Board
{
    internal interface ITileBoard
    {
        Vector2Int BoardSize { get; }

        Result Initialize(Func<TileType, bool>? tileValidator = null);
        Result Initialize(TileType[,] startingTiles, Func<TileType, bool>? tileValidator = null);
        bool IsValidPosition(int x, int y);
        ITile? GetTile(int x, int y);
        void SetTile(int x, int y, ITile tile);
        void SwapTiles(Vector2Int pos1, Vector2Int pos2);
        Stack<ITile>[] RefillBoard();
    }
}