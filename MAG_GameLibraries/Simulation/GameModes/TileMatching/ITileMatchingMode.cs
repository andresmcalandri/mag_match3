using MAG_GameLibraries.Simulation.Tile;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    public interface ITileMatchingMode : IGameMode
    {
        ITile[] Match();
    }
}
