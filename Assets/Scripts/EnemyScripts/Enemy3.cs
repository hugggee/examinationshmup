using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float movementSpeed = 5f; // rörelsehastighet
    public Playerdata CurrentPlayerData = null; // data referens
    public GameObject OffScreenChecker = null;

    // Lägg till en händelse för när fienden dör
    public event System.Action OnEnemyDeath;

    void Update()
    {
        MoveForward(); // Rör fienden framåt

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
}
