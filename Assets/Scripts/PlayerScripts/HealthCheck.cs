using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCheck : MonoBehaviour
{
    public Playerdata CurrentPlayerData = null; // Referens till din PlayerData-klass, du kan dra och sl�ppa din spelare p� detta f�lt i Unity-inspekt�ren.

    private void Update()
    {
        // Kontrollera spelarens h�lsa
        if (CurrentPlayerData != null && CurrentPlayerData.HP <= 0)
        {
            // Om spelarens h�lsa �r 0 eller mindre, byt scenen till huvudmenyn
            SceneManager.LoadScene("mainmenu");
        }
    }
}
