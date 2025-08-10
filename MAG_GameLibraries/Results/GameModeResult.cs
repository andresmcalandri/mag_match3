using MAG_GameLibraries.Simulation.GameModes;

namespace MAG_GameLibraries.Results
{
    public class GameModeResult : Result
    {
        // TODO Not compiling due to standard 2.1 ??
        //[MemberNotNullWhen(false, nameof(HasError))]
        public IGameMode? GameMode { get; }

        public GameModeResult (IGameMode gameMode) : base()
        {
            GameMode = gameMode;
        }

        public GameModeResult(Error error) : base(error) 
        {
            GameMode = null;
        }
    }
}