using MAG_GameLibraries.Simulation.Tile;
using System;
using System.Linq;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Board
{
    internal class TileBoardFactory : ITileBoardFactory
    {
        private readonly ITileFactory _tileFactory;

        public TileBoardFactory(ITileFactory tileFactory)
        {
            _tileFactory = tileFactory ?? throw new ArgumentNullException(nameof(tileFactory));
        }

        public ITileBoard CreateBoard(TileBoardConfig config)
        {
            ValidateConfig(config);
            return new DefaultTileBoard(config.BoardSize, _tileFactory, config.RefillableTileTypes);
        }

        private void ValidateConfig(TileBoardConfig config)
        {
            if (config.BoardSize == Vector2Int.zero)
                throw new ArgumentException("Board Size needs to be greater than 0", nameof(config.BoardSize));

            if (config.RefillableTileTypes.GroupBy(t => t.TileId).Any(g => g.Count() > 1))
                throw new ArgumentException("There are duplicate tile id's in the supported list", nameof(config.RefillableTileTypes));
        }
    }
}
