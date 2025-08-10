using MAG_GameLibraries.Simulation.GameModes.TileMatching;
using MAG_GameLibraries.Simulation.Tile;
using System;
using UnityEngine;

public class Match3GameBehavior : MonoBehaviour
{
    [SerializeField]
    private TileMatchingConfig _tileMatchingConfig;

    [SerializeField]
    private BoardView _boardView;

    [SerializeField]
    private TileView _tilePrefab;

    private ITileMatchingMode _gameMode;

    void Start()
    {
        var createResult = MAGRuntimeHolder.Instance.GetGameMode(_tileMatchingConfig);
        if (createResult.HasError)
        {
            Debug.LogError(createResult.Error);
            return;
        }

        _gameMode = createResult.GameMode as ITileMatchingMode;

        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeGame()
    {
        var result = _gameMode.Initialize();
        if (result.HasError)
        {
            Debug.LogError(result.Error);
            //TODO Should be able to deferr error to error handler view
            return;
        }

        var initializeResult = _gameMode.Initialize();
        if (initializeResult.HasError)
        {
            Debug.LogError(initializeResult.Error);
            return;
        }

        InitializeView();
    }

    private void InitializeView()
    {
        var tiles = _gameMode.GetCurrentTiles();
        _boardView.Initialize(tiles, _tilePrefab, TileClicked);
    }

    private void TileClicked(Vector2Int clickedTilePosition)
    {
        var result = _gameMode.Match(clickedTilePosition.x, clickedTilePosition.y);
        if (result.HasError)
        {
            Debug.LogError(result.Error);
            return;
        }

        HandleMatchResult(result);
    }

    private void HandleMatchResult(MatchingResult matchedTiles)
    {
        _boardView.PopTiles(matchedTiles.MatchedTiles);
    }
}
