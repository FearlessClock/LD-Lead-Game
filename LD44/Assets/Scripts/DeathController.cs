using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
