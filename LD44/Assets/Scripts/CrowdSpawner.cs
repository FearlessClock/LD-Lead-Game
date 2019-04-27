using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{
    [SerializeField] private int nmbrOfCrowds;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] crowdPeople;
    [SerializeField] private CrowdManager crowdManager;

    private void Awake()
    {
        List<Transform> positions = new List<Transform>();
        positions.AddRange(spawnPositions);
        nmbrOfCrowds = Random.Range(nmbrOfCrowds / 2, nmbrOfCrowds);
        for (int i = 0; i < nmbrOfCrowds; i++)
        {
            if(positions.Count == 0)
            {
                break;
            }
            int index = Random.Range(0, positions.Count);
            Transform position = positions[index];
            positions.RemoveAt(index);

            GameObject obj = Instantiate<GameObject>(crowdPeople[Random.Range(0, crowdPeople.Length)], position);
            crowdManager.OnCheer.AddListener(obj.GetComponent<CrowdController>().Cheer);
        }
    }
}
