using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPatterns;

    public float spawnTime;
    public float decreaseTime;
    public float minTime;

    private float timer = 0;

    private void Start()
    {
        SpawnRandomEnemyPattern();
    }

    private void Update()
    {
        if (timer >= spawnTime)
        {
            SpawnRandomEnemyPattern();
            timer = 0;

            if (spawnTime > minTime)
            {
                spawnTime -= decreaseTime;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void SpawnRandomEnemyPattern()
    {
        int rand = Random.Range(0, enemyPatterns.Length);
        Instantiate(enemyPatterns[rand], transform.position, Quaternion.identity);
    }
}
