using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelLoader loader = FindObjectOfType<LevelLoader>();

            if (loader != null)
            {
                loader.ShowLose();
            }
        }
    }
}

