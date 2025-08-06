using UnityEngine;

namespace MAG_GameLibraries.Simulation.Tile
{
    public class TileType : ScriptableObject
    {
        [SerializeField]
        public string Name { get; }

        [SerializeField]
        public Material Material { get; }
    }
}