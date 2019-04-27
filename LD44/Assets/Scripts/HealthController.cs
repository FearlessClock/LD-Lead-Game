using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float health;

    public UnityEvent OnDeath;
    public void TakeDamage(float amount)
    {
        health -= amount;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(health <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
