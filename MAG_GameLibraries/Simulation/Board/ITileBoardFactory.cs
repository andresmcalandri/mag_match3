using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.GameModes.TileMatching;

internal interface ITileBoardFactory
{
    ITileBoard CreateBoard(TileMatchingConfig config);
}