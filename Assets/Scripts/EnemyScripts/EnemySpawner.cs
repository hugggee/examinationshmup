using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject commonEnemyPrefab = null;
    public GameObject rareEnemyPrefab = null;
    public GameObject fastEnemyPrefab = null; // New enemy type
    public Playerdata playerData;

    private int currentRound = 1;
    private int currentWave = 1;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentRound <= 3)
        {
            while (currentWave <= 3)
            {
                yield return SpawnEnemiesForWave();
                yield return new WaitUntil(() => AllEnemiesDead());
                currentWave++;
            }

            currentWave = 1;
            currentRound++;

            if (playerData != null)
            {
                playerData.HP += 10;
            }

            SceneManager.LoadScene("Round" + currentRound);
        }

        SceneManager.LoadScene("slutskärm");
    }

    IEnumerator SpawnEnemiesForWave()
    {
        int commonEnemyCount = currentRound * currentWave * 2;
        int rareEnemyCount = currentRound * currentWave;
        int fastEnemyCount = currentRound * currentWave; // Adjust count as needed

        SpawnCommonEnemies(commonEnemyCount);
        SpawnRareEnemies(rareEnemyCount);
        SpawnFastEnemies(fastEnemyCount); // Spawn the new enemy type

        yield break;
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

    void SpawnFastEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject enemy = Instantiate(fastEnemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            enemy.GetComponent<Enemy3>().OnEnemyDeath += HandleEnemyDeath; // Replace NewEnemyScript with the actual script for the new enemy
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(14f, 20f);
        float y = Random.Range(-6f, 6f);
        return new Vector3(x, y, 0f);
    }

    void HandleEnemyDeath()
    {
        // Handle enemy death if needed
    }

    bool AllEnemiesDead()
    {
        return GameObject.FindObjectsOfType<Enemy>().Length == 0 &&
               GameObject.FindObjectsOfType<Enemy2>().Length == 0 &&
               GameObject.FindObjectsOfType<Enemy3>().Length == 0; // Replace NewEnemyScript with the actual script for the new enemy
    }
}
