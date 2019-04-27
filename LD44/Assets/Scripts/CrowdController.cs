using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float cheerTime;
    
    public void Cheer()
    {
        StartCoroutine("Cheering");
    }

    private IEnumerator Cheering()
    {
        yield return new WaitForSeconds(Random.Range(0f, 0.4f));
        animator.SetFloat("Speed", Random.Range(0.7f, 1.5f));
        animator.SetBool("Cheer", true);
        yield return new WaitForSeconds(cheerTime + Random.Range(0f, 0.4f));
        animator.SetBool("Cheer", false);
    }
}
