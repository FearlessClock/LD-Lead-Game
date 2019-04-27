using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public string WaveName;
    public GameObject[] EnemyOrder;
    public float[] EnemyTimings;
    public int[] EnemySpawnLocation;
}
