using MAG_GameLibraries.Simulation.GameModes.TileMatching;
using Microsoft.Extensions.DependencyInjection;

namespace MAG_GameLibraries.Services
{
    public class MAGRuntime
    {
        public MAGRuntime()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<ITileMatchingHeuristicFactory, HeuristicFactory>();
        }
    }
}
