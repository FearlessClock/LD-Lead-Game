using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShoppingZoneEnterController : MonoBehaviour
{
    public UnityEvent OnZoneEnter;
    public UnityEvent OnZoneExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnZoneEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnZoneExit?.Invoke();
        }
    }
}
