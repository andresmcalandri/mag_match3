using MAG_GameLibraries.Documentation;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.Tile
{
    [CustomerFacing]
    [CreateAssetMenu(fileName = "TileType", menuName = "MAG/Tile Matching/Tile Type")]
    public class TileType : ScriptableObject
    {
        [SerializeField]
        public string? Name;

        [SerializeField]
        public Material? Material;
    }
}