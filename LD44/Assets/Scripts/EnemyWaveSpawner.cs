using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWaveSpawner : MonoBehaviour
{
    public Wave[] Waves;
    public GameObject[] EnemyOrder;
    public float[] EnemyTimings;
    public int[] EnemySpawnLocations;
    public Transform[] SpawnLocations;

    public float SpawnRadius = 0.0f;
    private Vector3 RandomOffset;

    [SerializeField] private IntVariable WaveNumber;
    public bool IsWaveFinished;

    public GameObject[] Enemies;

    public UnityEvent OnWaveFinished;
    public UnityEvent OnRoundsFinished;

    void Start()
    { 
        NextWave();
    }

    IEnumerator SpawnEnemies()
    {
        IsWaveFinished = false;
        for (int i = 0; i < EnemyOrder.Length; i++)
        {
            yield return new WaitForSeconds(EnemyTimings[i]);
            RandomOffset = new Vector3(Random.Range(-SpawnRadius, SpawnRadius), 0, Random.Range(-SpawnRadius, SpawnRadius));
            Instantiate(EnemyOrder[i], SpawnLocations[EnemySpawnLocations[i]].position + RandomOffset, Quaternion.identity);
        }
        IsWaveFinished = true;
    }

    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (IsWaveFinished == true && Enemies.Length == 0)
        {
            if (WaveNumber >= Waves.Length)
            {
                OnRoundsFinished?.Invoke();
            }
            else
            {
                OnWaveFinished?.Invoke();
            }
        }
    }

    public void NextWave()
    {
        if (WaveNumber < Waves.Length)
        {
            EnemyOrder = Waves[WaveNumber].EnemyOrder;
            EnemyTimings = Waves[WaveNumber].EnemyTimings;
            EnemySpawnLocations = Waves[WaveNumber].EnemySpawnLocation;
            StartCoroutine("SpawnEnemies");
            WaveNumber.SetValue(WaveNumber + 1);
        }
    }

    public void ForceNextWave()
    {
        NextWave();
    }
}
