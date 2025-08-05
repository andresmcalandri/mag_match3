using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.GameModes.TileMatching;

internal interface ITileBoardFactory
{
    ITileBoard CreateBoard(ITileMatchingConfig config);
}