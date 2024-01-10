using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyboulet : MonoBehaviour
{
    public Playerdata CurrentPlayerData = null; // data referens

    public void DealDamage()
    {
        CurrentPlayerData.HP -= 2;
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

}
