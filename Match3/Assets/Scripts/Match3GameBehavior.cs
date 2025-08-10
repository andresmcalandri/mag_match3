using MAG_GameLibraries.Simulation.GameModes.TileMatching;
using UnityEngine;

public class Match3GameBehavior : MonoBehaviour
{
    [SerializeField]
    private TileMatchingConfig _tileMatchingConfig;

    [SerializeField]
    private Transform _boardContainer;

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

        for (int x = 0; x < _tileMatchingConfig.BoardConfig.BoardSize.x; x++)
        {
            for (int y = 0; y < _tileMatchingConfig.BoardConfig.BoardSize.y; y++)
            {
                var tile = tiles[x, y];

                //TODO Should probably show an empty Tile model?
                if (tile is null)
                    continue;

                var newTile = Instantiate(_tilePrefab, _boardContainer);
                newTile.Initialize(tile.Metadata);
                newTile.transform.localPosition = new Vector3(x, y, 0);
            }
        }
    }
}
