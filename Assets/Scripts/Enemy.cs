using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.RegisterEnemy();


        //gm = FindObjectOfType<GameManager>();

        //if (gm != null)
        //{
        //    gm.RegisterEnemy();
        //    Debug.Log("Enemy Registered");
        //}
        //else
        //{
        //    Debug.Log("GameManager NOT FOUND");
        //}
    }

    public void Die()
    {
        gm.EnemyKilled();
        Destroy(gameObject);
    }
}

