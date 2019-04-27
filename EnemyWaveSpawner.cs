using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public Wave[] Waves;
    public GameObject[] EnemyOrder;
    public float[] EnemyTimings;
    public int[] EnemySpawnLocations;
    public Transform[] SpawnLocations;

    public float SpawnRadius = 0.0f;
    private Vector3 RandomOffset;

    void Start()
    { 
        NextWave();
        StartWave();
    }

    public void StartWave()
    {
        StartCoroutine("SpawnEnemies");
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i <= EnemyOrder.Length; i++)
        {
            RandomOffset = new Vector3(Random.Range(-SpawnRadius, SpawnRadius), 0, Random.Range(-SpawnRadius, SpawnRadius));
            Instantiate(EnemyOrder[i], SpawnLocations[EnemySpawnLocations[i]].position, Quaternion.identity);
            yield return new WaitForSeconds(EnemyTimings[i]);
        }
        yield return null;
    }

    public void NextWave()
    {
        EnemyOrder = Waves[0].EnemyOrder;
        EnemyTimings = Waves[0].EnemyTimings;
        EnemySpawnLocations = Waves[0].EnemySpawnLocation;
    }
}
