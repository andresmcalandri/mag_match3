using MAG_GameLibraries.Documentation;
using MAG_GameLibraries.Simulation.Tile;
using System.Collections.Generic;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Board
{
    [CustomerFacing]
    [CreateAssetMenu(fileName = "MAG", menuName = "Config/Tile Board Config")]
    public class TileBoardConfig : ScriptableObject
    {
        /// <summary>
        /// Collection of the supported tiles to initialize and refill the board
        /// </summary>
        public Vector3 BoardSize;
        public ITileType[]? RefillableTileTypes;
        public ITileType[,]? StartingTiles;
        public Vector3 RefillDirection;
    }
}
