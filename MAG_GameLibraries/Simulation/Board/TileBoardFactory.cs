using MAG_GameLibraries.Simulation.GameModes.TileMatching;
using MAG_GameLibraries.Simulation.Tile;
using System;
using System.Numerics;

namespace MAG_GameLibraries.Simulation.Board
{
    internal class TileBoardFactory : ITileBoardFactory
    {
        private readonly ITileFactory _tileFactory;

        public TileBoardFactory(ITileFactory tileFactory)
        {
            _tileFactory = tileFactory ?? throw new ArgumentNullException(nameof(tileFactory));
        }

        public ITileBoard CreateBoard(ITileMatchingConfig config)
        {
            ValidateConfig(config);
            return new DefaultTileBoard(Vector2.Zero, _tileFactory, Array.Empty<TileType>());
           
        }

        private void ValidateConfig(ITileMatchingConfig config)
        {
           throw new NotImplementedException();
        }
    }
}
