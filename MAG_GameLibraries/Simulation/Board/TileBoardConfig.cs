using MAG_GameLibraries.Documentation;
using MAG_GameLibraries.Simulation.Tile;
using System;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Board
{
    [CustomerFacing]
    [CreateAssetMenu(fileName = "BoardConfig", menuName = "MAG/Tile Matching/Tile Board Config")]
    public class TileBoardConfig : ScriptableObject
    {
        /// <summary>
        /// Collection of the supported tiles to initialize and refill the board
        /// </summary>
        public Vector3 BoardSize;
        public TileType[] RefillableTileTypes = Array.Empty<TileType>();
        public TileType[,]? StartingTiles;
        public Vector3 RefillDirection;
    }
}
