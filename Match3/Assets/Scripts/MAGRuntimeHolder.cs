using MAG_GameLibraries.Services;
using Microsoft.Extensions.DependencyInjection;
using UnityEngine;

public class MAGRuntimeHolder : MonoBehaviour
{
    public static ServiceProvider ServiceProvider => _instance.ServiceProvider;

    private static MAGRuntime _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        
        _instance = new MAGRuntime();
        DontDestroyOnLoad(gameObject);
    }
}
