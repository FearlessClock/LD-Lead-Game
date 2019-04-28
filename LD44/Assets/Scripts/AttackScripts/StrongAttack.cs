using UnityEngine;
using System.Collections;

public class StrongAttack : aAttack
{
    public override void Attack(HitBoxController hitBoxController)
    {
        OnAttackThrow?.Invoke();
        bool hitLanded = false;
        GameObject[] hits = hitBoxController.Hit();
        foreach (GameObject enemy in hits)
        {
            HealthController hc = enemy.GetComponent<HealthController>();
            if (hc)
            {
                hc.TakeDamage(attackDamage);
                hitLanded = true;
            }
        }
        if (hitLanded)
        {
            OnAttackLand?.Invoke();
        }
    }
}
