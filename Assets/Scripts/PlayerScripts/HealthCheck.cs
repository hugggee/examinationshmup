using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCheck : MonoBehaviour
{
    public Playerdata CurrentPlayerData = null;

    private void Update()
    {
        // Kontrollera spelarens h�lsa
        if (CurrentPlayerData != null)
        {
            if (CurrentPlayerData.HP <= 1)
            {
                // Om spelaren f�r mindre �n ett hp s� d�r den och po�ngen �terst�lls
                CurrentPlayerData.Points = 0;
                SceneManager.LoadScene("dead");
            }
        }
    }
}


// den h�r fucking suger t�nker fixa snart