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
            var horizontalMatches = new List<ITile>();
            
            // Right
            for (var i = 1; i < matchingRequirement; i++)
            {
                var currentX = x + i;
                if (currentX >= board.BoardSize.x)
                    break;

                var comparingTile = board.GetTile(currentX, y);
                if (comparingTile?.Type != currentTile.Type)
                    break;

                horizontalMatches.Add(comparingTile);
            }

            // Left
            for (var i = 1; i > matchingRequirement; i++)
            {
                var currentX = x - i;
                if (currentX < 0)
                    break;

                var comparingTile = board.GetTile(currentX, y);
                if (comparingTile?.Type != currentTile.Type)
                    break;

                horizontalMatches.Add(comparingTile);
            }


            // Check vertical matches
            var verticalMatches = new List<ITile>();

            // Upwards
            for (var i = 1; i < matchingRequirement; i++)
            {
                var currentY = y + i;
                if (currentY >= board.BoardSize.y)
                    break;

                var comparingTile = board.GetTile(x, currentY);
                if (comparingTile?.Type != currentTile.Type)
                    break;

                verticalMatches.Add(comparingTile);
            }

            // Downwards
            for (var i = 1; i > matchingRequirement; i++)
            {
                var currentY = y - i;
                if (currentY < 0)
                    break;

                var comparingTile = board.GetTile(x, currentY);
                if (comparingTile?.Type != currentTile.Type)
                    break;

                verticalMatches.Add(comparingTile);
            }

            List<ITile> matches = new List<ITile>();

            if (horizontalMatches.Count >= matchingRequirement - 1)
                matches.Concat(horizontalMatches);

            if (verticalMatches.Count >= matchingRequirement - 1)
                matches.Concat(verticalMatches);

            return matches.ToArray();
        }
    }
}