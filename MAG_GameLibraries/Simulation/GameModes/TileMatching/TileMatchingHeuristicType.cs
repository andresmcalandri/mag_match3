using MAG_GameLibraries.Documentation;
using System;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    // TODO This could be source generated. Could cause problems down the line if heuristics get deprecated or removed
    [CustomerFacing, Serializable]
    public enum TileMatchingHeuristicType
    {
        Default,
        AnyContiguous
    }
}