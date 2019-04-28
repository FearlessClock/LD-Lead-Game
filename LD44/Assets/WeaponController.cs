using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private aWeapon weapon;
    [SerializeField] private new SpriteRenderer renderer;

    [SerializeField] private HitBoxController hitBoxController;

    private void Awake()
    {
        renderer.sprite = weapon.weaponSprite;
    }

    public float GetDamage(eAttackType attackType)
    {
        return weapon.GetDamage(attackType);
    }

    public void ApplyEffect(GameObject target)
    {
        weapon.ApplyAbility(target);
    }

    public bool ThrowWeakAttack()
    {
        bool hitLanded = false;
        GameObject[] hits = hitBoxController.Hit();
        foreach (GameObject enemy in hits)
        {
            HealthController hc = enemy.GetComponent<HealthController>();
            if (hc)
            {
                this.ApplyEffect(enemy);
                hc.TakeDamage(this.GetDamage(eAttackType.Weak));
                hitLanded = true;
            }
        }
        if (hitLanded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ThrowStrongAttack()
    {
        bool hitLanded = false;
        GameObject[] hits = hitBoxController.Hit();
        foreach (GameObject enemy in hits)
        {
            HealthController hc = enemy.GetComponent<HealthController>();
            if (hc)
            {
                this.ApplyEffect(enemy);
                hc.TakeDamage(this.GetDamage(eAttackType.Strong));
                hitLanded = true;
            }
        }
        if (hitLanded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
