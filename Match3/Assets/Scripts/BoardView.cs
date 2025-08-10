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

                var newTile = GetOrCreateTile(tilePrefab);
                newTile.Initialize(position, tile.Metadata);
                newTile.transform.localPosition = new Vector3(x, y, 0);
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

    private void OnTileClicked(Vector2Int tilePosition)
    {
        _onTileClicked?.Invoke(tilePosition);
    }

    private void RecycleTile(Vector2Int position)
    {
        var activeTile = _activeTiles[position.x, position.y];
        if (activeTile != null)
        {
            activeTile.gameObject.SetActive(false);
            _unusedTiles.Push(activeTile);
            _activeTiles[position.x, position.y] = null;
        }
    }

    private TileView GetOrCreateTile(TileView tilePrefab)
    {
        if (_unusedTiles.TryPop(out var tile))
        {
            tile.gameObject.SetActive(true);
            return tile;
        }

        var newTile = Instantiate(tilePrefab, transform);
        return newTile;
    }
}
