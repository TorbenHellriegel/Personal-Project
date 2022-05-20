using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemys;
    public TextMeshProUGUI waveText;

    private int wave;
    private int maxEnemys;
    private int strongestEnemyType;
    private int difficulty;
    private int enemyCount;
    public float spawnRate = 3;
    private float spawnAreaX = 70;
    private float spawnPositionZ = 50;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        waveText.text = "Wave " + wave;
        maxEnemys = 1;
        strongestEnemyType = 1;
        difficulty = 0;
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        // Count enemys
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        // If there are no more enemys start a new wave
        if(enemyCount == 0)
        {
            // Increase wave number
            wave++;
            waveText.text = "Wave " + wave;

            // Increase either the amont of enemys or their difficulty
            switch (Random.Range(0, 2))
            {
                case 0:
                    maxEnemys++;
                    break;
                default:
                    difficulty++;
                    break;
            }

            // Determine which enemy wave to spawn
            if(wave % 10 == 0)
            {
                int randomIndex = Random.Range(0, enemys.Length);
                EnemyController enemy = Instantiate(enemys[randomIndex],
                                            new Vector3(Random.Range(-spawnAreaX, spawnAreaX), 5, spawnPositionZ),
                                            transform.rotation)
                                            .GetComponent<EnemyController>();
                maxEnemys = wave/10 + 1;
                strongestEnemyType = wave/10 + 1;
                difficulty = wave/10 * 3;
            }
            else
            {
                SpawnWave();
            }
        }
    }

    // Spawns an enemy wave
    private void SpawnWave()
    {
        for (int i = 0; i < maxEnemys; i++)
        {
            SpawnRandomEnemy();
        }
    }

    // Spawns a random enemy
    private void SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, Mathf.Min(enemys.Length, strongestEnemyType));
        EnemyController enemy = Instantiate(enemys[randomIndex],
                                            new Vector3(Random.Range(-spawnAreaX, spawnAreaX), 5, spawnPositionZ),
                                            transform.rotation)
                                            .GetComponent<EnemyController>();

        // Give the enemy random stat upgrades based on difficulty
        for (int i = 0; i < difficulty; i++)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    enemy.shootingSpeed += 0.2f;
                    break;
                case 1:
                    enemy.maxHealth += 3;
                    break;
                case 3:
                    enemy.multiShot += 2;
                    break;
                default:
                    break;
            }
        }
    }
}
