using UnityEngine;
using System.Collections;

public abstract class aWeapon : ScriptableObject
{
    [SerializeField] protected float damage;
    public Sprite weaponSprite;
    public abstract float GetDamage();
    public abstract void ApplyAbility(GameObject target);
}
