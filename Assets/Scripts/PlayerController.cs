using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class playerController : MonoBehaviour
{
    [Header("Rolling")]
    public float angularSpeed = 90f;   // constant roll speed
    private float rollDirection = 0f;  // -1 left, +1 right
    private bool isRolling = false;

    [Header("Shooting")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 35f;
    public float recoilStrength = 4f;

    private Rigidbody2D rb;
    public LevelLoader levelLoader;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
         if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        return;


        if (Input.GetMouseButtonDown(0) )
        {
            Shoot();
        }

        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        if (isRolling)
        {
            rb.angularVelocity = rollDirection * angularSpeed;
        }
    }

    void Shoot()
    {


        // Get shooting direction
        Vector2 shootDir = firePoint.right.normalized;

        // Spawn bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = shootDir * bulletSpeed;

        // Apply recoil (opposite direction)
        Vector2 recoilDir = -shootDir;
        rollDirection = Mathf.Sign(recoilDir.x);

        // Start rolling after first shot
        isRolling = true;

        // Small push so physics reacts immediately
        rb.AddForce(recoilDir * recoilStrength, ForceMode2D.Impulse);
    }

}




    //[Header("Ammo")]
    // public int maxAmmo = 6;
    // private int currentAmmo;
    // public TMP_Text ammoText;
     
        //currentAmmo = maxAmmo;  in start
        //UpdateAmmoUI();


       // levelLoader.ShowLose(); in shhoot()
       //if (currentAmmo <= 0)
       //{
       //  return;
       //}

       // currentAmmo--;
       // UpdateAmmoUI();


        //  bool pressed = // in update
        // Input.GetMouseButtonDown(0) ||
        // (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);

        //  if (pressed)
        //  {
        //     Shoot();
        //  }


//    void UpdateAmmoUI()
//{
//    if (ammoText != null)
//        ammoText.text = "Ammo: " + currentAmmo;
//}

//public void AddAmmo(int amount)
//{
//    currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
//    UpdateAmmoUI();
//}