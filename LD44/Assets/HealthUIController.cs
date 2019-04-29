using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIController : MonoBehaviour
{
    [SerializeField] private FloatVariable playerHealth;
    [SerializeField] private GameObject heartPrefab;
    private void Awake()
    {
        playerHealth.OnValueChanged.AddListener(UpdateHearts);
        UpdateHearts(playerHealth);
    }
    public void UpdateHearts(float value)
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < value; i++)
        {
            Instantiate<GameObject>(heartPrefab, this.transform);
        }
    }
}
