using MAG_GameLibraries.Results;

namespace MAG_GameLibraries.Simulation.GameModes
{
    internal interface IGameModeFactory
    {
        GameModeResult Create(IGameConfig gameConfig);
    }
}