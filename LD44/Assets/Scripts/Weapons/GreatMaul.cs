using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Great Maul", menuName = "Weapons/Great Maul", order = 0)]
class GreatMaul : aWeapon
{
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
                strongDamage = 3;
                return strongDamage;
            case eAttackType.Weak:
                weakDamage = 2;
                return weakDamage;
            default:
                return 0;
        }
    }
}