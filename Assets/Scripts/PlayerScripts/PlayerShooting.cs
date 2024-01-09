using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab; // prefaben för skotten
    public Transform firePoint; // var skotten kommer ut ifrån

    public float projectileSpeed = 10f; // fart
    public float fireRate = 0.5f; // firerate

    private float nextFireTime = 0f; // nästa tillåten skjut tid
    private bool isFiring = false; // om den skjuter

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            isFiring = true; // variabel till true när man börjar skjuta
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false; // variabel till false när man slutar skjuta
        }

        if (isFiring && Time.time > nextFireTime) // om sant skjut skottet
        {
            FireProjectile();
            nextFireTime = Time.time + 1f / fireRate; // uppdatera nästa time beroende av fireraten
        }
    }

    void FireProjectile()
    {
        // skapa skottet från punkten där den skjuts utifrån med dens rotation från dens position
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // få rigidbody2d
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // farten av rigidbody
        rb.velocity = firePoint.up * projectileSpeed;

        Destroy(projectile, 5.0f);
    }
}
