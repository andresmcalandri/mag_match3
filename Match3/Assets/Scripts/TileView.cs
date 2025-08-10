using MAG_GameLibraries.Simulation.Tile;
using System;
using UnityEngine;

public class TileView : MonoBehaviour
{
    public void Initialize(object metadata)
    {
        if (metadata is not TileMetadata tileMetadata)
            throw new ArgumentException($"Metadata for Tile {gameObject.name} is invalid", nameof(metadata));
        
        SetTileMaterial(tileMetadata.Material);
    }

    private void SetTileMaterial(Material material)
    {
        gameObject.GetComponentInChildren<Renderer>().material = material;
    }
}
