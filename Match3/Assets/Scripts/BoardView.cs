using MAG_GameLibraries.Simulation.Tile;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoardView : MonoBehaviour
{
    private TileView[,] _activeTiles;
    private Stack<TileView> _unusedTiles;

    private Action<Vector2Int> _onTileClicked;
    private bool _initialized = false;
    private TileView _tilePrefab;

    private void Awake()
    {
        _unusedTiles = new Stack<TileView>();
    }

    public void Initialize(ITile[,] tiles, TileView tilePrefab, Action<Vector2Int> onTileClicked)
    {
        if (_initialized)
            return;

        _initialized = true;
        _onTileClicked += onTileClicked;
        _tilePrefab = tilePrefab;
        _activeTiles = new TileView[tiles.GetLength(0), tiles.GetLength(1)];

        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                var position = new Vector2Int(x, y);
                RecycleTile(position);

                var tile = tiles[x, y];

                //TODO Should probably show an empty Tile model?
                if (tile is null)
                    continue;

                var newTile = GetOrCreateTile();
                newTile.Initialize(position, tile.Id, tile.Metadata);
                _activeTiles[x, y] = newTile;
                newTile.OnTileClicked += OnTileClicked;
            }
        }
    }

    public void PopTiles(ITile[] matchedTiles)
    {
        foreach (var tile in matchedTiles)
        {
            //TODO Add animations and fancy stuff
            RecycleTile(tile.Position);
        }
    }

    public void UpdateTilePositionsPerRow(Queue<ITile>[] compactedTiles)
    {
        for (int x = 0; x < compactedTiles.Length; x++)
        {
            var compactedTilesInColumn = compactedTiles[x];
            while (compactedTilesInColumn.TryDequeue(out var tile))
            {
                for (int y = 0; y < _activeTiles.GetLength(1); y++)
                {
                    var activeTile = _activeTiles[x, y];

                    if (activeTile == null || activeTile.Id != tile.Id)
                        continue;

                    activeTile.SetTilePosition(new Vector2Int(tile.Position.x, tile.Position.y));
                    _activeTiles[tile.Position.x, tile.Position.y] = activeTile;
                    _activeTiles[x, y] = null;

                    break;
                }
            }
        }
    }

    internal void RefillPerRow(Stack<ITile>[] refilledTiles)
    {
        foreach (var refilledRow in refilledTiles)
        {
            while (refilledRow.TryPop(out var tile))
            {
                var newTile = GetOrCreateTile();
                newTile.Initialize(tile.Position, tile.Id, tile.Metadata);
                _activeTiles[tile.Position.x, tile.Position.y] = newTile;
            }
        }
    }

    private void OnTileClicked(Vector2Int tilePosition)
    {
        _onTileClicked?.Invoke(tilePosition);
    }

    private void RecycleTile(Vector2Int position)
    {
        RecycleTile(position.x, position.y);
    }

    private void RecycleTile(int x, int y)
    {
        var activeTile = _activeTiles[x, y];
        if (activeTile != null)
        {
            activeTile.gameObject.SetActive(false);
            _unusedTiles.Push(activeTile);
            _activeTiles[x, y] = null;
        }
    }

    private TileView GetOrCreateTile()
    {
        if (_unusedTiles.TryPop(out var tile))
        {
            tile.gameObject.SetActive(true);
            return tile;
        }

        var newTile = Instantiate(_tilePrefab, transform);
        return newTile;
    }
}
