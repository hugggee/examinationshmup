using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectilePrefab; // referens till projektil-prefab
    public Transform firePoint; // var skottet kommer ifrån
    public float movementSpeed = 5f; // rörelsehastighet
    public float fireRate = 1f; // skott per sekund
    public float bulletspeed = 6.0f; // använder -transform.right (kom ihåg till senare)
    public Playerdata CurrentPlayerData = null; // data referens
    public GameObject OffScreenChecker = null;

    // Lägg till en händelse för när fienden dör
    public event System.Action OnEnemyDeath;

    private float nextFireTime = 0f; // nästa tillåtna skotttid

    void Update()
    {
        MoveForward(); // Rör fienden framåt

        if (Time.time > nextFireTime)
        {
            FireProjectile(); // avfyra nästa projektil
            nextFireTime = Time.time + 1.0f / fireRate; // Nästa tillgängliga skott
        }
        if (OffScreenChecker.transform.position.x > transform.position.x)
        {
            // Lösgör händelsen för fiendens död
            OnEnemyDeath?.Invoke();

            DealDamage();
        }
    }

    public void DealDamage()
    {
        CurrentPlayerData.HP -= 10;
        // Lösgör händelsen för fiendens död
        OnEnemyDeath?.Invoke();

        GameObject.Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerComp = collision.gameObject.GetComponent<PlayerController>();
        if (playerComp != null)
        {
            DealDamage();
        }
    }

    public void TakeDamage()
    {
        // Lösgör händelsen för fiendens död
        OnEnemyDeath?.Invoke();

        GameObject.Destroy(gameObject);
    }

    void MoveForward()
    {
        // Rör fienden framåt
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    void FireProjectile()
    {
        // skapa projektilen från eldpositionens position och rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // få rigidbodyn
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // sätt hastigheten för rigidbodyn
        rb.velocity = firePoint.right * -bulletspeed;

        // Förstör projektilen när den är utanför skärmen efter 2 sekunder
        Destroy(projectile, 40.0f);
    }
}
