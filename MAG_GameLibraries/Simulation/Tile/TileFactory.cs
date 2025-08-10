using System;

namespace MAG_GameLibraries.Simulation.Tile
{
    internal class TileFactory : ITileFactory
    {
        private ulong _IDCount;
        public ITile Create(TileType tileType)
        {
            // TODO There could be potentially different types of supported tiles?
            // Right now seems unnecessary though
            return new Tile(tileType.TileId, _IDCount++, tileType.Metadata);
        }
    }
}
