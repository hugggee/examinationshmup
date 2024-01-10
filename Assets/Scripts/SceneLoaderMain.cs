using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderMain : MonoBehaviour
{
    public Playerdata playerData; // Drag and drop your PlayerData class into this field in the Unity inspector.

    public void LoadScene(string sceneName)
    {
        if (playerData != null)
        {
            if (playerData.HP <= 0)
            {
                playerData.HP = 10; // Set the player's HP to 10 only if it's currently 0
            }
        }

        SceneManager.LoadScene(sceneName);
    }
}
