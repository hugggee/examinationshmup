using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject commonEnemyPrefab = null; // orefab1
    public GameObject rareEnemyPrefab = null;   // prefab2
    public int rounds = 3;               // hur mång arundor
    public int commonEnemyMultiplier = 2; // hur många gånger fienden ska öka beroende på vilken runda
    public int rareEnemyMultiplier = 1;   // samma sak fast med ovanlig fiende

    private int currentRound = 1; // vilken runda

    // hade stora problem med serializedfield, vet inte hur jag skulle göra utan det så ändrade det
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentRound <= rounds)
        {
            int commonEnemyCount = commonEnemyMultiplier * currentRound;
            int rareEnemyCount = rareEnemyMultiplier * currentRound;

            SpawnCommonEnemies(commonEnemyCount);
            SpawnRareEnemies(rareEnemyCount);

            // vänta tills det inte finns några aktiva fiender kvar
            yield return new WaitUntil(() => AllEnemiesDead());

            // öka currentRound med 1 när alla fiender är döda
            currentRound++;
        }

        // byt scen när alla rundor är klara
        SceneManager.LoadScene("slutskärm");
    }

    void SpawnCommonEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject enemy = Instantiate(commonEnemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            enemy.GetComponent<Enemy>().OnEnemyDeath += HandleEnemyDeath;
        }
    }

    void SpawnRareEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject enemy = Instantiate(rareEnemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            enemy.GetComponent<Enemy2>().OnEnemyDeath += HandleEnemyDeath;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        // random spawn position
        float x = Random.Range(14f, 20f);
        float y = Random.Range(-6f, 6f);
        return new Vector3(x, y, 0f);
    }

    void HandleEnemyDeath()
    {
 
    }

    bool AllEnemiesDead()
    {
        // Om det finns fiender i scenen och om inte så är alla fiender döda och nästa runda börjar
        return GameObject.FindObjectsOfType<Enemy>().Length == 0 && GameObject.FindObjectsOfType<Enemy2>().Length == 0;
    }
}
