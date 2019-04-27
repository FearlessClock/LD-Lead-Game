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

    public int WaveNumber;
    public bool IsWaveFinished;

    public GameObject[] Enemys;

    void Start()
    { 
        NextWave();
    }

    public void StartWave()
    {
        StartCoroutine("SpawnEnemies");
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < EnemyOrder.Length; i++)
        {
            yield return new WaitForSeconds(EnemyTimings[i]);
            RandomOffset = new Vector3(Random.Range(-SpawnRadius, SpawnRadius), 0, Random.Range(-SpawnRadius, SpawnRadius));
            Instantiate(EnemyOrder[i], SpawnLocations[EnemySpawnLocations[i]].position + RandomOffset, Quaternion.identity);
            if (i == EnemyOrder.Length - 1)
            {
                IsWaveFinished = true;
            }
        }

    }

    void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (IsWaveFinished == true && Enemys.Length == 0)
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        EnemyOrder = Waves[WaveNumber].EnemyOrder;
        EnemyTimings = Waves[WaveNumber].EnemyTimings;
        EnemySpawnLocations = Waves[WaveNumber].EnemySpawnLocation;
        WaveNumber = WaveNumber + 1;
        StartWave();
    }
}
