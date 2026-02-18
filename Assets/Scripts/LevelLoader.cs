using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public MonoBehaviour playerController;

    public GameObject pausePanel;
    bool isPaused;
    public GameObject youLosePanel;
    public GameObject pauseButton;
    private bool gameEnded = false;
    public GameObject levelManager;
    public GameObject menu;
    private void Start()
    {
        pausePanel.SetActive(false);
        levelManager.SetActive(false);
        menu.SetActive(true);
    }
    public void LoadNextLevel()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {

        if (gameEnded) return;

        isPaused = true;
        playerController.enabled = false; // stop shooting
        Time.timeScale = 0f;
        pausePanel.SetActive(true);

    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        playerController.enabled = true;

    }

    public void ShowLose()
    {
        if (gameEnded) return;

        gameEnded = true;

        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        youLosePanel.SetActive(true);
    }

    public void SetGameEnded()
    {
        gameEnded = true;
    }
    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LevelManager()
    {
        menu.SetActive(false);
        levelManager.SetActive(true);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}



