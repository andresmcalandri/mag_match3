using MAG_GameLibraries.Simulation.Tile;
using System.Numerics;

namespace MAG_GameLibraries.Simulation.Board
{
    public class DefaultTileBoard : ITileBoard
    {
        public ITile[,] CurrentTiles => throw new System.NotImplementedException();

        public Vector2 BoardSize { get; }

        private ITileType[] _supportedTiles;
        private ITileFactory _tileFactory;

        internal DefaultTileBoard(Vector2 boardSize, ITileFactory tileFactory, ITileType[] supportedTiles) 
        { 
            BoardSize = boardSize;
            _tileFactory = tileFactory;
            _supportedTiles = supportedTiles;
        }

        public ITile GetTile(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public void Initialize(ITile[,]? startingTiles = null)
        {
            throw new System.NotImplementedException();
        }

        public bool IsValidPosition(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public void RefillBoard()
        {
            throw new System.NotImplementedException();
        }

        public void SetTile(int x, int y, ITile tile)
        {
            throw new System.NotImplementedException();
        }

        public void SwapTiles(Vector2 pos1, Vector2 pos2)
        {
            throw new System.NotImplementedException();
        }
    }
}