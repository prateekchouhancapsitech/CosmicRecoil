using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt("CurrentLevel", 0);
        SceneManager.LoadScene("Gameplay"); // use your gameplay scene name
    }

    public void LoadLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("CurrentLevel", levelIndex);
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
