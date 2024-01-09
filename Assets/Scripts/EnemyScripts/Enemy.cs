using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectilePrefab; // referens till projektil-prefab
    public Transform firePoint; // var skottet kommer ifr�n
    public float movementSpeed = 5f; // r�relsehastighet
    public float fireRate = 1f; // skott per sekund
    public float bulletspeed = 6.0f; // anv�nder -transform.right (kom ih�g till senare)
    public Playerdata CurrentPlayerData = null; // data referens
    public GameObject OffScreenChecker = null;

    // L�gg till en h�ndelse f�r n�r fienden d�r
    public event System.Action OnEnemyDeath;

    private float nextFireTime = 0f; // n�sta till�tna skotttid

    void Update()
    {
        MoveForward(); // R�r fienden fram�t

        if (Time.time > nextFireTime)
        {
            FireProjectile(); // avfyra n�sta projektil
            nextFireTime = Time.time + 1.0f / fireRate; // N�sta tillg�ngliga skott
        }
        if (OffScreenChecker.transform.position.x > transform.position.x)
        {
            // L�sg�r h�ndelsen f�r fiendens d�d
            OnEnemyDeath?.Invoke();

            DealDamage();
        }
    }

    public void DealDamage()
    {
        CurrentPlayerData.HP -= 10;
        // L�sg�r h�ndelsen f�r fiendens d�d
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
        // L�sg�r h�ndelsen f�r fiendens d�d
        OnEnemyDeath?.Invoke();

        GameObject.Destroy(gameObject);
    }

    void MoveForward()
    {
        // R�r fienden fram�t
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    void FireProjectile()
    {
        // skapa projektilen fr�n eldpositionens position och rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // f� rigidbodyn
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // s�tt hastigheten f�r rigidbodyn
        rb.velocity = firePoint.right * -bulletspeed;

        // F�rst�r projektilen n�r den �r utanf�r sk�rmen efter 2 sekunder
        Destroy(projectile, 40.0f);
    }
}
