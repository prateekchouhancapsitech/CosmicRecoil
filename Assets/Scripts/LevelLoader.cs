using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelLoader : MonoBehaviour
{
    public playerController playerController;

    public GameObject pausePanel;
    public GameObject youLosePanel;
    public GameObject pauseButton;

    public GameObject levelManager;
    public GameObject menu;

    private bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (youLosePanel != null)
            youLosePanel.SetActive(false);

        if (levelManager != null)
            levelManager.SetActive(false);

        if (menu != null)
            menu.SetActive(true);
    }

    // ================= PAUSE =================

    public void PauseGame()
    {
        if (gameEnded) return;

        Time.timeScale = 0f;

        if (playerController != null)
            playerController.canShoot = false;

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        if (playerController != null)
            playerController.canShoot = true;

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    // ================= LOSE =================

    public void ShowLose()
    {
        if (gameEnded) return;

        gameEnded = true;

        Time.timeScale = 0f;

        if (pauseButton != null)
            pauseButton.SetActive(false);

        if (youLosePanel != null)
            youLosePanel.SetActive(true);

        if (playerController != null)
            playerController.canShoot = false;
    }

    public void SetGameEnded()
    {
        gameEnded = true;
    }

    // ================= MENU =================

    public void OpenLevelSelect()
    {
        if (menu != null)
            menu.SetActive(false);

        if (levelManager != null)
            levelManager.SetActive(true);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGameState()
    {
        gameEnded = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (youLosePanel != null)
            youLosePanel.SetActive(false);
    }

}
