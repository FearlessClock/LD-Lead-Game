using UnityEngine;
using System.Collections;

public class WeakAttack : aAttack
{
    public override void Attack(HitBoxController hitBoxController)
    {
        GameObject[] hits = hitBoxController.Hit();
        foreach (GameObject enemy in hits)
        {
            HealthController hc = enemy.GetComponent<HealthController>();
            if (hc)
            {
                hc.TakeDamage(attackDamage);
            }
        }
    }
}
