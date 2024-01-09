using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject commonEnemyPrefab = null; // orefab1
    public GameObject rareEnemyPrefab = null;   // prefab2
    public int rounds = 3;               // hur m�ng arundor
    public int commonEnemyMultiplier = 2; // hur m�nga g�nger fienden ska �ka beroende p� vilken runda
    public int rareEnemyMultiplier = 1;   // samma sak fast med ovanlig fiende

    private int currentRound = 1; // vilken runda

    // hade stora problem med serializedfield, vet inte hur jag skulle g�ra utan det s� �ndrade det
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

            // v�nta tills det inte finns n�gra aktiva fiender kvar
            yield return new WaitUntil(() => AllEnemiesDead());

            // �ka currentRound med 1 n�r alla fiender �r d�da
            currentRound++;
        }

        // byt scen n�r alla rundor �r klara
        SceneManager.LoadScene("slutsk�rm");
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
        // Om det finns fiender i scenen och om inte s� �r alla fiender d�da och n�sta runda b�rjar
        return GameObject.FindObjectsOfType<Enemy>().Length == 0 && GameObject.FindObjectsOfType<Enemy2>().Length == 0;
    }
}
