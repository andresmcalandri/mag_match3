using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.Tile;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal class AnyContiguousTileMatchingHeuristic : ITileMatchingHeuristic
    {
        public ITile[] Match(ITileBoard board, int x, int y, int matchingRequirement)
        {
            var currentTile = board.GetTile(x, y);
            if (currentTile == null)
                return Array.Empty<ITile>();

            var matches = new HashSet<ITile>();
            var visited = new HashSet<(int x, int y)>();

            FloodFillMatches(board, currentTile.TileId, x, y, matches, visited);

            return matches.Count >= matchingRequirement ? matches.ToArray() : Array.Empty<ITile>();
        }

        public bool WouldMatch(ITileBoard board, TileType tileType, int x, int y, int matchingRequirement)
        {
            var matches = new HashSet<ITile>();
            var visited = new HashSet<(int x, int y)>();

            // Right
            FloodFillMatches(board, tileType.TileId, x + 1, y, matches, visited);
            // Left
            FloodFillMatches(board, tileType.TileId, x - 1, y, matches, visited);
            // Up
            FloodFillMatches(board, tileType.TileId, x, y + 1, matches, visited);
            // Down
            FloodFillMatches(board, tileType.TileId, x, y - 1, matches, visited);

            return matches.Count >= matchingRequirement - 1;
        }

        private void FloodFillMatches(ITileBoard board, string tileId, int x, int y, HashSet<ITile> matches, HashSet<(int x, int y)> visited)
        {
            if (x < 0 || x >= board.BoardSize.x || y < 0 || y >= board.BoardSize.y)
                return;

            if (visited.Contains((x, y)))
                return;

            var tile = board.GetTile(x, y);
            if (tile == null || tile.TileId != tileId)
                return;

            visited.Add((x, y));
            matches.Add(tile);
            
            // Right
            FloodFillMatches(board, tileId, x + 1, y, matches, visited); 
            // Left
            FloodFillMatches(board, tileId, x - 1, y, matches, visited);
            // Up
            FloodFillMatches(board, tileId, x, y + 1, matches, visited);
            // Down
            FloodFillMatches(board, tileId, x, y - 1, matches, visited);
        }
    }
}