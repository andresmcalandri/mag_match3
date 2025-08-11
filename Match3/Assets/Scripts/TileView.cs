using MAG_GameLibraries.Simulation.Tile;
using System;
using UnityEngine;

public class TileView : MonoBehaviour
{
    public Action<Vector2Int> OnTileClicked;
    public ulong Id => _id;

    private Vector2Int _tilePosition;
    private ulong _id;

    public void Initialize(Vector2Int position, ulong id, object metadata)
    {
        if (metadata is not TileMetadata tileMetadata)
            throw new ArgumentException($"Metadata for Tile {gameObject.name} is invalid", nameof(metadata));

        SetTilePosition(position);
        _id = id;

        SetTileMaterial(tileMetadata.Material);
    }

    public void SetTilePosition(Vector2Int newPosition)
    { 
        _tilePosition = newPosition;
        transform.localPosition = new Vector3(newPosition.x, newPosition.y, 0);
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
