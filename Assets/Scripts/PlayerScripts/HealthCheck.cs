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
                // Om spelarens h�lsa �r 1 eller mindre, byt scenen till huvudmenyn
                SceneManager.LoadScene("mainmenu");
            }
            else if (SceneManager.GetActiveScene().name == "mainmenu")
            {
                // Om spelaren �r i huvudmenyn, �terst�ll h�lsan till 10
                CurrentPlayerData.HP = 10;
            }
        }
    }
}
