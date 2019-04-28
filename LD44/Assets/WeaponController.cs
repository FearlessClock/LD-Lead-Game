using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private aWeapon weapon;
    [SerializeField] private new SpriteRenderer renderer;
    
    private void Awake()
    {
        renderer.sprite = weapon.weaponSprite;
    }

    public float GetDamage()
    {
        return weapon.GetDamage();
    }

    public void ApplyEffect(GameObject target)
    {
        weapon.ApplyAbility(target);
    }
}
