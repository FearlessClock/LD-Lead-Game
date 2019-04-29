using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    [SerializeField] private float hitDistance;
    [SerializeField] private bool useStatic;
    [SerializeField] private FloatVariable hitDistanceVar;
    [SerializeField] private Transform hitStartPoint;
    [SerializeField] private LayerMask hitLayer;

    private Collider2D[] hits = new Collider2D[10];

    public float GetHitDistance()
    {
        if (useStatic)
        {
            return hitDistanceVar;
        }
        else
        {
            return hitDistance;
        }
    }

    public GameObject[] Hit()
    {
        List<GameObject> thingsHit = new List<GameObject>();
        int nmbrOfHits = Physics2D.OverlapBoxNonAlloc(hitStartPoint.position, new Vector2(hitDistance, 0.5f), 0, hits, hitLayer);

        if (nmbrOfHits > 0)
        {
            for (int i = 0; i < nmbrOfHits; i++)
            {
                if (hits[i].gameObject.Equals(this.gameObject))
                {
                    continue;
                }
                thingsHit.Add(hits[i].gameObject);
            }
        }
        return thingsHit.ToArray();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(hitStartPoint.position, new Vector3(hitDistance, 0.5f, 0));
    }
}
