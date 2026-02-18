using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    public LevelLoader levelLoader;

void OnCollisionEnter2D(Collision2D collision)
    {
    if (collision.gameObject.CompareTag("Player"))
    {
        levelLoader.ShowLose();
    }
    }

}
