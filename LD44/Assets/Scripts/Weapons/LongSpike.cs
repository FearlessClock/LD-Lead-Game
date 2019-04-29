using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Long Spike", menuName = "Weapons/Long Spike", order = 0)]
class LongSpike : aWeapon
{
    [SerializeField] private FloatVariable PlayerRange;
    public float PlusRange;
    private bool HasAddedRange;

    public override void ApplyAbility(GameObject target)
    {
        // For other weapons, do things like slow the enemy, apply weird damage things etc
        if (HasAddedRange != true)
        {
            PlayerRange.SetValue(PlayerRange + PlusRange);
        }
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