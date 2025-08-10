using System;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Tile
{
    internal class TileFactory : ITileFactory
    {
        private ulong _IDCount;

        public ITile Create(TileType tileType, Vector2Int position)
        {
            // TODO There could be potentially different types of supported tiles?
            // Right now seems unnecessary though
            return new Tile(tileType.TileId, _IDCount++, position, tileType.Metadata);
        }
    }
}
