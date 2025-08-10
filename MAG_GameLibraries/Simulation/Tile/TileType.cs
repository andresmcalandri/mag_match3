using MAG_GameLibraries.Documentation;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Tile
{
    [CustomerFacing]
    [CreateAssetMenu(fileName = "TileType", menuName = "MAG/Tile Matching/Tile Type")]
    public class TileType : ScriptableObject
    {
        // TODO With a layer of code anylisis we could source generate enums from another config file
        public string TileId = "";

        public ScriptableObject? Metadata;
    }
}