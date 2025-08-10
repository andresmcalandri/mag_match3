using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.Tile;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    public class RefillResult : IResult
    {
        [MemberNotNullWhen(false, "HasError")]
        public Stack<ITile>[]? RefilledTiles { get; }
        public MatchingResult? MatchingResult { get; }
        public Error? Error { get; }
        public bool HasError => Error != null;

        public RefillResult(Stack<ITile>[] refilledTiles, MatchingResult? matchingResult = null)
        {
            RefilledTiles = refilledTiles;
            MatchingResult = matchingResult;
            Error = null;
        }

        public RefillResult(Error error)
        {
            RefilledTiles = null;
            MatchingResult = null;
            Error = error;
        }
    }
}
