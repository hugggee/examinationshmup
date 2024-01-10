using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCheck : MonoBehaviour
{
    public Playerdata CurrentPlayerData = null;

    private void Update()
    {
        // Kontrollera spelarens hälsa
        if (CurrentPlayerData != null)
        {
            if (CurrentPlayerData.HP <= 1)
            {
                // Om spelaren får mindre än ett hp så dör den och poängen återställs
                CurrentPlayerData.Points = 0;
                SceneManager.LoadScene("dead");
            }
        }
    }
}


// den här fucking suger tänker fixa snart