using MAG_GameLibraries.Simulation.GameModes;
using MAG_GameLibraries.Simulation.Tile;
using System.Diagnostics.CodeAnalysis;

namespace MAG_GameLibraries.Results
{
    public readonly struct GameModeResult : IResult
    {
        [MemberNotNullWhen(false, "HasError")]
        public IGameMode? GameMode { get; }

        public Error? Error { get; }
        public bool HasError => Error != null;

        public GameModeResult (IGameMode gameMode)
        {
            GameMode = gameMode;
            Error = null;
        }

        public GameModeResult(Error error)
        {
            Error = error;
            GameMode = null;
        }
    }
}