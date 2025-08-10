using MAG_GameLibraries.Simulation.Tile;
using System;
using UnityEngine;

public class TileView : MonoBehaviour
{
    public Action<Vector2Int> OnTileClicked;

    private Vector2Int _tilePosition;

    public void Initialize(Vector2Int position, object metadata)
    {
        if (metadata is not TileMetadata tileMetadata)
            throw new ArgumentException($"Metadata for Tile {gameObject.name} is invalid", nameof(metadata));

        _tilePosition = position;

        SetTileMaterial(tileMetadata.Material);
    }

    void OnMouseDown()
    {
        OnTileClicked?.Invoke(_tilePosition);
    }

    private void SetTileMaterial(Material material)
    {
        gameObject.GetComponentInChildren<Renderer>().material = material;
    }
}
