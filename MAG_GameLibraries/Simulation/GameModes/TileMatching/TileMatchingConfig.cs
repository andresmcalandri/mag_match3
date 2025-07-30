using MAG.Documentation;
using System.Numerics;

namespace MAG.GameModes.TileMatching
{
    [CustomerFacing]
    public interface ITileMatchingConfig
    {
        ITileMatchingHeuristic TileMatchingHeuristic { get; }
        ITileType[] TileTypes { get; }
        Vector2 BoardSize { get; }
    }
}
