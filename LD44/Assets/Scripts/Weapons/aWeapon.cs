using UnityEngine;
using System.Collections;

public enum eAttackType { Strong, Weak }
public abstract class aWeapon : Item
{
    [SerializeField] protected float weakDamage;
    [SerializeField] protected float strongDamage;
    public Sprite weaponSprite;
    public abstract float GetDamage(eAttackType attackType);
    public abstract void ApplyAbility(GameObject target);
}
