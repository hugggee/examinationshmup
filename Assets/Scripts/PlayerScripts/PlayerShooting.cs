using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform firePoint; // Transform representing the point where projectiles will be spawned

    public float projectileSpeed = 10f; // Speed of the projectile

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            FireProjectile(); // Call the method to fire a projectile
        }
    }

    void FireProjectile()
    {
        // Instantiate a new projectile at the firePoint position and rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D component of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity of the projectile to move straight forward
        rb.velocity = firePoint.up * projectileSpeed; // Use firePoint.up instead of transform.up

        // Destroy the projectile after a certain time (adjust this value based on your needs)
        Destroy(projectile, 2.0f);
    }
}
