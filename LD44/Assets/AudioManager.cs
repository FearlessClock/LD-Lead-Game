using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot arenaFull;
    [SerializeField] private AudioMixerSnapshot arenaZero;
    [SerializeField] private AudioMixerSnapshot shopFull;
    [SerializeField] private AudioMixerSnapshot shopZero;

    public void OnShopLoad()
    {
        arenaZero.TransitionTo(1);
        shopFull.TransitionTo(1);
    }

    public void OnShopDone()
    {
        arenaFull.TransitionTo(1);
        shopZero.TransitionTo(1);
    }
}
