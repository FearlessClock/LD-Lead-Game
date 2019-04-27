using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] SpawnPosititions;
    public GameObject[] Enemies;
    public int[] EnemySpawnCondition;

    public int WaveCount;
    public int WaveAddAmount;
    public int WaveSpawnCount;
    private int SpawnPosRand;
    public float SpawnRadius = 0.0f;
    private Vector3 RandomOffset;

    public int EnemiesSpawned;
    public int EnemiesAlive;

    void Start()
    {
        WaveCount = 1;
        StartWave();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartWave();
        }        
    }

    public void StartWave()
    {
        WaveSpawnCount = WaveCount + (WaveAddAmount * WaveCount);
        for (int i = 0; i < WaveSpawnCount && EnemiesAlive <= 10; i++)
        {
            StartCoroutine("SpawnEnemy");
            EnemiesAlive = EnemiesAlive + 1;
        }
        WaveCount = WaveCount + 1;

    }

    IEnumerator SpawnEnemy()
    {
//        yield return new WaitUntil(() => (EnemiesAlive <= 10));
        SpawnPosRand = Random.Range(0, SpawnPosititions.Length);
        RandomOffset = new Vector3(Random.Range(-SpawnRadius, SpawnRadius), 0, Random.Range(-SpawnRadius, SpawnRadius));
        
        EnemiesSpawned = EnemiesSpawned + 1;
        if (EnemiesSpawned % EnemySpawnCondition[2] == 0)
        {
            Instantiate(Enemies[3], SpawnPosititions[SpawnPosRand].position + RandomOffset, Quaternion.identity);
        }
        else if (EnemiesSpawned % EnemySpawnCondition[1] == 0)
        {
            Instantiate(Enemies[2], SpawnPosititions[SpawnPosRand].position + RandomOffset, Quaternion.identity);
        }
        else if (EnemiesSpawned % EnemySpawnCondition[0] == 0)
        {
            Instantiate(Enemies[1], SpawnPosititions[SpawnPosRand].position + RandomOffset, Quaternion.identity);
        }
        else
        {
            Instantiate(Enemies[0], SpawnPosititions[SpawnPosRand].position + RandomOffset, Quaternion.identity);
        }
        yield return null;
    }

    public void EnemyDie()
    {
        EnemiesAlive = EnemiesAlive - 1;
    }
}
