using UnityEngine;

namespace MAG_GameLibraries.Simulation.Tile
{
    internal interface ITileFactory
    {
        ITile Create(TileType tileType, Vector2Int position);
    }
}
