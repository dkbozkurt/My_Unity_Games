using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [Range(0.0F, 40.0F)]
    public float spawnRange = 25f;

    [Range(0.0F, 10F)]
    public float spawnDelay = 5f;
    private float _timer;

    private int totalEnemySpawned;
    private int checkPointEnemySpawnedNumber;

    public float rightLaneCenter;
    public int rightLaneSpawnerLow;
    public int rightLaneSpawnerHigh;
    public int numRightLaneCars;
    

    void Start()
    {
        _timer = 0f;
        totalEnemySpawned = 0;
        checkPointEnemySpawnedNumber = 10;
    }
    
    void Update()
    {
        if (enemyPrefab != null)
        {
            _timer += Time.deltaTime;
            if (_timer >= spawnDelay)
            {
                _timer = 0f;
                SpawnEnemy();
            }

        }
    }

    
    private void SpawnEnemy()
    {
        int randomNumber = Random.Range(0, 3);
        Vector3 position = new Vector3(Random.Range(-spawnRange, spawnRange), 2, Random.Range(-spawnRange, spawnRange));
        Instantiate(enemyPrefab[randomNumber], position, Quaternion.identity);
        
        totalEnemySpawned++;
        if (totalEnemySpawned >= checkPointEnemySpawnedNumber)
        {
            checkPointEnemySpawnedNumber += totalEnemySpawned;
            if (spawnDelay > 0.5f)
            {
                spawnDelay -= 0.2f;
            }
        }
    }
}

