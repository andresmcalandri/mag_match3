using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string _gameplaySceneName;

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(_gameplaySceneName);
    }
}
