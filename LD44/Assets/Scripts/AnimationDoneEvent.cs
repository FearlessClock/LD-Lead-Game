using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationDoneEvent : MonoBehaviour
{
    public UnityEvent OnAnimationFinished;
    public void AnimationDone()
    {
        OnAnimationFinished?.Invoke();
    }
}
