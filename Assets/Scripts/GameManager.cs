using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winPanel;
    public playerController playerController;
// your shooting / movement script
    public GameObject pauseButton;


    private int enemyCount;

    void Start()
    {
         winPanel.gameObject.SetActive(false);
        
        // enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void RegisterEnemy()
    {
    enemyCount++;
    }


    public void EnemyKilled()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            ShowWin();
        }
    }

    void ShowWin()
    {
        FindObjectOfType<LevelLoader>().SetGameEnded();
        pauseButton.SetActive(false);
        winPanel.gameObject.SetActive(true);
        playerController.enabled = false; // stop shooting
        Time.timeScale = 0f;
    }

}
