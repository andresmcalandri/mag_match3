using MAG_GameLibraries.Documentation;
using MAG_GameLibraries.Simulation.Board;
using System;
using UnityEngine;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    [CustomerFacing]
    [CreateAssetMenu(fileName = "TileMatchingGameConfig", menuName = "MAG/Tile Matching/Game Config")]
    public class TileMatchingConfig : ScriptableObject, IGameConfig
    {
        public TileMatchingHeuristicType TileMatchingHeuristic;
        public TileBoardConfig? BoardConfig;
        public int MatchingNumber = 3;
        public bool MatchOnRefill = false;
    }
}
