
namespace MAG_GameLibraries.Simulation.Tile
{
    public interface ITile
    {
        ulong Id { get; }
        string TileId { get; }
        object? Metadata { get; }
    }
}
