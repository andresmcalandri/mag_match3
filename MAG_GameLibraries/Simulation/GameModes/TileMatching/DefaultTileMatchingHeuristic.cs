using MAG_GameLibraries.Simulation.Board;
using MAG_GameLibraries.Simulation.Tile;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MAG_GameLibraries.Simulation.GameModes.TileMatching
{
    internal class DefaultTileMatchingHeuristic : ITileMatchingHeuristic
    {
        public ITile[] Match(ITileBoard board, int x, int y, int matchingRequirement)
        {
            var currentTile = board.GetTile(x, y);
            if (currentTile == null)
                return Array.Empty<ITile>();

            // Check horizontal match
            var horizontalMatches = CheckHorizontalMatches(board, currentTile.TileId, x, y, matchingRequirement);

            // Check vertical matches
            var verticalMatches = CheckVerticalMatches(board, currentTile.TileId, x, y, matchingRequirement);

            var matches = new List<ITile>();
            if (horizontalMatches.Count >= matchingRequirement - 1)
                matches.AddRange(horizontalMatches);

            if (verticalMatches.Count >= matchingRequirement - 1)
                matches.AddRange(verticalMatches);

            return matches.ToArray();
        }

        public bool WouldMatch(ITileBoard board, TileType tileType, int x, int y, int matchingRequirement)
        {
            var horizontalMatches = CheckHorizontalMatches(board, tileType.TileId, x, y, matchingRequirement);
            if (horizontalMatches.Count >= matchingRequirement - 1)
                return true;

            return CheckVerticalMatches(board, tileType.TileId, x, y, matchingRequirement).Count >= matchingRequirement - 1;
        }

        private List<ITile> CheckHorizontalMatches(ITileBoard board, string tileId, int x, int y, int matchingRequirement)
        {
            var horizontalMatches = new List<ITile>();
            // Right
            for (var i = 1; i < matchingRequirement; i++)
            {
                var currentX = x + i;
                if (currentX >= board.BoardSize.x)
                    break;

                var comparingTile = board.GetTile(currentX, y);
                if (comparingTile is null || comparingTile.TileId != tileId)
                    break;

                horizontalMatches.Add(comparingTile);
            }

            // Left
            for (var i = 1; i < matchingRequirement; i++)
            {
                var currentX = x - i;
                if (currentX < 0)
                    break;

                var comparingTile = board.GetTile(currentX, y);
                if (comparingTile is null || comparingTile.TileId != tileId)
                    break;

                horizontalMatches.Add(comparingTile);
            }

            return horizontalMatches;
        }

        private List<ITile> CheckVerticalMatches(ITileBoard board, string typeId, int x, int y, int matchingRequirement)
        {
            var verticalMatches = new List<ITile>();
            // Upwards
            for (var i = 1; i < matchingRequirement; i++)
            {
                var currentY = y + i;
                if (currentY >= board.BoardSize.y)
                    break;

                var comparingTile = board.GetTile(x, currentY);
                if (comparingTile is null || comparingTile.TileId != typeId)
                    break;

                verticalMatches.Add(comparingTile);
            }

            // Downwards
            for (var i = 1; i < matchingRequirement; i++)
            {
                var currentY = y - i;
                if (currentY < 0)
                    break;

                var comparingTile = board.GetTile(x, currentY);
                if (comparingTile is null || comparingTile.TileId != typeId)
                    break;

                verticalMatches.Add(comparingTile);
            }

            return verticalMatches;
        }
    }
}