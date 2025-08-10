using MAG_GameLibraries.Services;
using UnityEngine;

public class MAGRuntimeHolder : MonoBehaviour
{
    public static MAGRuntime Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = new MAGRuntime();
        DontDestroyOnLoad(gameObject);
    }
}
