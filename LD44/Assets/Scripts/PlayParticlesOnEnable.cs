using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticlesOnEnable : MonoBehaviour
{
    private new ParticleSystem particleSystem;
    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        particleSystem.Play();
    }

    private void OnDisable()
    {
        particleSystem.Stop();
    }
}
