using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField] private new ParticleSystem particleSystem;

    public void Play()
    {
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
    }

    public void Stop()
    {
        if (particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
    }
}
