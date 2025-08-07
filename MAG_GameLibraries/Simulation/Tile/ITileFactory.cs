namespace MAG_GameLibraries.Simulation.Tile
{
    internal interface ITileFactory
    {
        ITile Create(TileType tileType);
    }
}
