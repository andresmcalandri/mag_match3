using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.GameModes;
using MAG_GameLibraries.Simulation.GameModes.TileMatching;
using MAG_GameLibraries.Simulation.Tile;
using Microsoft.Extensions.DependencyInjection;

namespace MAG_GameLibraries.Services
{
    public class MAGRuntime
    {
        public ServiceProvider ServiceProvider { get; }

        public MAGRuntime()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<ITileFactory, TileFactory>()
                .AddSingleton<ITileBoardFactory, TileBoardFactory>()
                .AddSingleton<ITileMatchingHeuristicFactory, TileMatchingHeuristicFactory>()
                .AddSingleton<IGameModeFactory, GameModeFactory>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
