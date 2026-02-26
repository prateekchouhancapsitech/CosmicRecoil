//using UnityEngine;

//public class LevelManager : MonoBehaviour
//{
//    [Header("Level Data")]
//    public LevelData[] levels;

//    [Header("Prefabs")]
//    public GameObject playerPrefab;
//    public GameObject enemyPrefab;
//    public GameObject boxPrefab;

//    int currentLevelIndex;

//    void Start()
//    {
//        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", 0);
//        LoadLevel(currentLevelIndex);
//    }

//    public void LoadLevel(int index)
//    {
//        ClearLevel();

//        if (index >= levels.Length)
//        {
//            Debug.Log("All Levels Completed!");
//            return;
//        }

//        currentLevelIndex = index;
//        LevelData level = levels[index];

//        // Spawn Player
//        Instantiate(playerPrefab,
//            level.playerStartPosition,
//            Quaternion.Euler(0, 0, level.playerStartRotation));

//        // Spawn Enemies
//        foreach (Vector2 pos in level.enemyPositions)
//        {
//            Instantiate(enemyPrefab, pos, Quaternion.identity);
//        }

//        // Spawn Boxes
//        foreach (Vector2 pos in level.boxPositions)
//        {
//            Instantiate(boxPrefab, pos, Quaternion.identity);
//        }
//    }

//    public void LoadNextLevel()
//    {
//        currentLevelIndex++;

//        PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
//        PlayerPrefs.Save();

//        LoadLevel(currentLevelIndex);
//    }

//    void ClearLevel()
//    {
//        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
//        foreach (GameObject e in enemies)
//            Destroy(e);

//        GameObject[] boxes = GameObject.FindGameObjectsWithTag("box");
//        foreach (GameObject b in boxes)
//            Destroy(b);

//        GameObject player = GameObject.FindGameObjectWithTag("Player");
//        if (player != null)
//            Destroy(player);
//    }
//}


//using UnityEngine;

//public class LevelManager : MonoBehaviour
//{
//    [Header("Level Data")]
//    public LevelData[] levels;

//    [Header("Prefabs")]
//    public GameObject playerPrefab;
//    public GameObject enemyPrefab;
//    public GameObject boxPrefab;

//    int currentLevelIndex;

//    void Start()
//    {
//        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", 0);
//        LoadLevel(currentLevelIndex);
//    }

//    public void LoadLevel(int index)
//    {
//        ClearLevel();

//        if (index >= levels.Length)
//        {
//            Debug.Log("All Levels Completed!");
//            return;
//        }

//        currentLevelIndex = index;
//        LevelData level = levels[index];

//        // ?? Spawn Player
//        GameObject player = Instantiate(playerPrefab,
//            level.playerStartPosition,
//            Quaternion.Euler(0, 0, level.playerStartRotation));

//        // ?? Get playerController from new player
//        playerController pc = player.GetComponent<playerController>();

//        // ?? Reset shooting for new level
//        if (pc != null)
//            pc.canShoot = true;

//        // ?? Update GameManager reference
//        GameManager gm = FindObjectOfType<GameManager>();
//        if (gm != null)
//            gm.playerController = pc;

//        // Spawn Enemies
//        foreach (Vector2 pos in level.enemyPositions)
//        {
//            Instantiate(enemyPrefab, pos, Quaternion.identity);
//        }

//        // Spawn Boxes
//        foreach (Vector2 pos in level.boxPositions)
//        {
//            Instantiate(boxPrefab, pos, Quaternion.identity);
//        }
//    }

//    public void LoadNextLevel()
//    {
//        currentLevelIndex++;

//        PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
//        PlayerPrefs.Save();

//        LoadLevel(currentLevelIndex);
//    }

//    void ClearLevel()
//    {
//        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
//        foreach (GameObject e in enemies)
//            Destroy(e);

//        GameObject[] boxes = GameObject.FindGameObjectsWithTag("box");
//        foreach (GameObject b in boxes)
//            Destroy(b);

//        GameObject player = GameObject.FindGameObjectWithTag("Player");
//        if (player != null)
//            Destroy(player);
//    }
//}




using UnityEngine;
using UnityEngine.SceneManagement;
using static LevelData;

public class LevelManager : MonoBehaviour
{
    [Header("Level Data")]
    public LevelData[] levels;

    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject boxPrefab;
    public GameObject blockPrefab;
    public GameObject spikePrefab;

    int currentLevelIndex;

    void Start()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", 0);
        LoadLevel(currentLevelIndex);
    }

    public void LoadLevel(int index)
    {
        Time.timeScale = 1f;

        ClearLevel();

        if (index >= levels.Length)
        {
            Debug.Log("All Levels Completed!");
            return;
        }

        currentLevelIndex = index;
        PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
        PlayerPrefs.Save();

        LevelData level = levels[index];

        // Spawn Player
        GameObject player = Instantiate(playerPrefab,
            level.playerStartPosition,
            Quaternion.Euler(0, 0, level.playerStartRotation));

        playerController pc = player.GetComponent<playerController>();
        if (pc != null)
            pc.canShoot = true;

        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
            gm.playerController = pc;

        // Spawn Enemies
        foreach (Vector2 pos in level.enemyPositions)
        {
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }

        // Spawn Boxes
        foreach (Vector2 pos in level.boxPositions)
        {
            Instantiate(boxPrefab, pos, Quaternion.identity);
        }

        // Close win panel automatically
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null && gameManager.winPanel != null)
            gameManager.winPanel.SetActive(false);

        LevelLoader loader = FindObjectOfType<LevelLoader>();
        if (loader != null)
        {
            loader.ResetGameState();

            if (loader.pauseButton != null)
                loader.pauseButton.SetActive(true);
        }

        foreach (BlockData block in level.blocks)
        {
            GameObject newBlock = Instantiate(
                blockPrefab,
                block.position,
                Quaternion.Euler(0, 0, block.rotation)
            );

            newBlock.transform.localScale = block.scale;
        }
        foreach (SpikeData spike in level.spikes)
        {
         GameObject newSpike =Instantiate(
           spikePrefab, 
           spike.position, 
           Quaternion.Euler(0, 0, spike.rotation)
           );

            newSpike.transform.localScale = spike.scale;
        }
    }

    public void LoadNextLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }

    public void RestartCurrentLevel()
    {
        LoadLevel(currentLevelIndex);
    }

    public void LoadLevelFromButton(int index)
    {
        LoadLevel(index);
    }

    void ClearLevel()
    {
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
            Destroy(e);

        foreach (GameObject b in GameObject.FindGameObjectsWithTag("box"))
            Destroy(b);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            Destroy(player);

        foreach (GameObject s in GameObject.FindGameObjectsWithTag("spike"))
            Destroy(s);

        foreach (GameObject b in GameObject.FindGameObjectsWithTag("block"))
            Destroy(b);
  
    }

}
