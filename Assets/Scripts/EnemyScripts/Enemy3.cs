using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float movementSpeed = 5f; // r�relsehastighet
    public Playerdata CurrentPlayerData = null; // data referens
    public GameObject OffScreenChecker = null;

    // L�gg till en h�ndelse f�r n�r fienden d�r
    public event System.Action OnEnemyDeath;

    void Update()
    {
        MoveForward(); // R�r fienden fram�t

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
}
