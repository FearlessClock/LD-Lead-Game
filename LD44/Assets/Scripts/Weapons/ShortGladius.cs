using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Short Gladius", menuName = "Weapons/Short Gladius", order = 0)]
class ShortGladius : aWeapon
{
    private FloatVariable playerHealth;
    public override void ApplyAbility(GameObject target)
    {
        // For other weapons, do things like slow the enemy, apply weird damage things etc
    }

    public override float GetDamage(eAttackType attackType)
    {
        //Calculate the damage to apply when hitting
        switch (attackType)
        {
            case eAttackType.Strong:
                strongDamage = 2;
                return strongDamage;
            case eAttackType.Weak:
                weakDamage = 1;
                return weakDamage;
            default:
                return 0;
        }
    }
}