using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Playerdata CurrentPlayerData = null; // data referens

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemyComp = collision.gameObject.GetComponent<Enemy>(); // vet inte om detta är smart att bara göra en till
        Enemy2 enemy2Comp = collision.gameObject.GetComponent<Enemy2>(); // men kommer inte på något bättre

        if (enemyComp != null)
        {
            enemyComp.TakeDamage();
            CurrentPlayerData.AddPoints(10);
            GameObject.Destroy(gameObject);
        }
        else if (enemy2Comp != null)
        {
            enemy2Comp.TakeDamage();
            CurrentPlayerData.AddPoints(15); // mer skadlig fiende, borde ge mer poäng
            GameObject.Destroy(gameObject);
        }
    }
}
