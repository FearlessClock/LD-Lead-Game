using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void OpenGate()
    {
        animator.SetBool("Open", true);
    }

    public void CloseGate()
    {
        animator.SetBool("Open", false);
    }
}
