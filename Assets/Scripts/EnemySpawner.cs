using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 3;
    private float spawnArea = 70;

    public GameObject[] enemy;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Repetedly spawns enemys
    private void Spawn()
    {
        Instantiate(enemy[0], new Vector3(Random.Range(-spawnArea, spawnArea+1), 5, 40), transform.rotation);
        Invoke("Spawn", spawnRate);
    }
}
