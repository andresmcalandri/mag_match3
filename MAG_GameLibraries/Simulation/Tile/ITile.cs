
namespace MAG_GameLibraries.Simulation.Tile
{
    public interface ITile
    {
        int Id { get; }
        TileType Type { get; }
        object? Metadata { get; }
    }
}
