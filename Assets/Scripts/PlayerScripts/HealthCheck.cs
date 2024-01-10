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
                // Om spelarens hälsa är 1 eller mindre, byt scenen till huvudmenyn
                SceneManager.LoadScene("mainmenu");
            }
            else if (SceneManager.GetActiveScene().name == "mainmenu")
            {
                // Om spelaren är i huvudmenyn, återställ hälsan till 10
                CurrentPlayerData.HP = 10;
            }
        }
    }
}
