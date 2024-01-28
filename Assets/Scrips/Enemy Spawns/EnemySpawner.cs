using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private TextMeshProUGUI roundText;

    private int currentRound = 1;
    private int enemiesPerRound = 5;
    private int enemiesSpawned = 0;

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerRound; i++)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            enemiesSpawned++;
        }
    }

    private void Update()
    {
        if (enemiesSpawned == enemiesPerRound)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                currentRound++;
                enemiesPerRound += 2; // Incrementa la cantidad de enemigos por ronda
                enemiesSpawned = 0;
                roundText.text = "Round: " + currentRound.ToString();
                SpawnEnemies();
            }
        }
    }
}