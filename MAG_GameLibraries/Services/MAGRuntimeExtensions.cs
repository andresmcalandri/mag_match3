using MAG_GameLibraries.Documentation;
using MAG_GameLibraries.Results;
using MAG_GameLibraries.Simulation.GameModes;
using Microsoft.Extensions.DependencyInjection;

namespace MAG_GameLibraries.Services
{
    [CustomerFacing]
    public static class MAGRuntimeExtensions
    {
        public static GameModeResult GetGameMode(this MAGRuntime magRuntime, IGameConfig gameConfig)
        {
            var gameModeFactory = magRuntime.ServiceProvider.GetService<IGameModeFactory>();
            if (gameModeFactory is null)
                throw new System.Exception($"Could't find {nameof(IGameModeFactory)} factory");

            return gameModeFactory.Create(gameConfig);
        }
    }
}
