using MAG_GameLibraries.Simulation.Tile;
using System.Collections.Generic;
using System.Numerics;

namespace MAG_GameLibraries.Simulation.Board
{
    internal interface ITileBoard
    {
        ITile[,] CurrentTiles { get; }
        Vector2 BoardSize { get; }

        void Initialize(ITile[,]? startingTiles = null);
        bool IsValidPosition(int x, int y);
        ITile GetTile(int x, int y);
        void SetTile(int x, int y, ITile tile);
        void SwapTiles(Vector2 pos1, Vector2 pos2);
        void RefillBoard();
    }
}