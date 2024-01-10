using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Playerdata CurrentPlayerData = null; // data referens

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemyComp = collision.gameObject.GetComponent<Enemy>();
        Enemy2 enemy2Comp = collision.gameObject.GetComponent<Enemy2>(); // detta sättet suger balle
        Enemy3 enemy3Comp = collision.gameObject.GetComponent<Enemy3>(); 

        if (enemyComp != null)
        {
            enemyComp.TakeDamage();
            CurrentPlayerData.AddPoints(10);
            GameObject.Destroy(gameObject);
        }
        else if (enemy2Comp != null)
        {
            enemy2Comp.TakeDamage();
            CurrentPlayerData.AddPoints(15);
            GameObject.Destroy(gameObject);
        }
        else if (enemy3Comp != null)
        {
            enemy3Comp.TakeDamage();
            CurrentPlayerData.AddPoints(5); // gubben skadar inte piss
            GameObject.Destroy(gameObject);
        }
    }
}
