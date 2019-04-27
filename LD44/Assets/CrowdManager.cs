using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrowdManager : MonoBehaviour
{
    public UnityEvent OnCheer;

    public void OnCheerCallback()
    {
        OnCheer?.Invoke();
    }
}
