using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene(int buildIndex) => SceneManager.LoadScene(buildIndex);
    public void LoadNextScene()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        buildIndex = SceneManager.sceneCountInBuildSettings > buildIndex ? buildIndex : 0;
        SceneManager.LoadScene(buildIndex);
    }
    public void LoadMainMenu() => SceneManager.LoadScene(0);
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void Quit() => Application.Quit();
}
