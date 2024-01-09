using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCheck : MonoBehaviour
{
    public Playerdata CurrentPlayerData = null; // Referens till din PlayerData-klass, du kan dra och släppa din spelare på detta fält i Unity-inspektören.

    private void Update()
    {
        // Kontrollera spelarens hälsa
        if (CurrentPlayerData != null && CurrentPlayerData.HP <= 0)
        {
            // Om spelarens hälsa är 0 eller mindre, byt scenen till huvudmenyn
            SceneManager.LoadScene("mainmenu");
        }
    }
}
