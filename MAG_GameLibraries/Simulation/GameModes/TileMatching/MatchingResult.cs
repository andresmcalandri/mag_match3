using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.Tile;
using System.Diagnostics.CodeAnalysis;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    public class MatchingResult : IResult
    {
        [MemberNotNullWhen(false, "HasError")]
        public ITile[]? MatchedTiles { get; }
        public RefillResult? RefillResult { get; }
        public Error? Error { get; }
        public bool HasError => Error != null;

        public MatchingResult(ITile[]? tiles = null, RefillResult? refillResult = null) 
        {
            RefillResult = refillResult;
            MatchedTiles = tiles;
            Error = null;
        }

        public MatchingResult(Error error)
        {
            RefillResult = null;
            MatchedTiles = null;
            Error = error;
        }
    }
}
