using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab; // prefaben f�r skotten
    public Transform firePoint; // var skotten kommer ut ifr�n

    public float projectileSpeed = 10f; // fart
    public float fireRate = 0.5f; // firerate

    private float nextFireTime = 0f; // n�sta till�ten skjut tid
    private bool isFiring = false; // om den skjuter

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            isFiring = true; // variabel till true n�r man b�rjar skjuta
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false; // variabel till false n�r man slutar skjuta
        }

        if (isFiring && Time.time > nextFireTime) // om sant skjut skottet
        {
            FireProjectile();
            nextFireTime = Time.time + 1f / fireRate; // uppdatera n�sta time beroende av fireraten
        }
    }

    void FireProjectile()
    {
        // skapa skottet fr�n punkten d�r den skjuts utifr�n med dens rotation fr�n dens position
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // f� rigidbody2d
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // farten av rigidbody
        rb.velocity = firePoint.up * projectileSpeed;

        Destroy(projectile, 5.0f);
    }
}
