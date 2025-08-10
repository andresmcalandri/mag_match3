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
        [MemberNotNullWhen(false, "HasError")]
        public Queue<ITile>[]? CompactedTiles { get; }
        public MatchingResult? MatchingResult { get; }
        public Error? Error { get; }
        public bool HasError => Error != null;

        public RefillResult(Stack<ITile>[] refilledTiles, Queue<ITile>[] compactedTiles, MatchingResult? matchingResult = null)
        {
            RefilledTiles = refilledTiles;
            CompactedTiles = compactedTiles;
            MatchingResult = matchingResult;
            Error = null;
        }

        public RefillResult(Error error)
        {
            RefilledTiles = null;
            CompactedTiles = null;
            MatchingResult = null;
            Error = error;
        }
    }
}
