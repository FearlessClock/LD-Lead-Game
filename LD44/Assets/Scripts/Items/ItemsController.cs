using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponController), typeof(BloodMagicController))]
public class ItemsController : MonoBehaviour
{
	private WeaponController weaponController;
    private BloodMagicController bloodMagicController;

    private void Awake()
    {
        weaponController = GetComponent<WeaponController>();
        bloodMagicController = GetComponent<BloodMagicController>();
    }

    public bool ThrowWeakAttack()
    {
        return weaponController.ThrowWeakAttack();
    }

    public bool ThrowStrongAttack()
    {
        return weaponController.ThrowStrongAttack();
    }

    public void CastBloodMagic()
    {
        bloodMagicController.CastBloodMagic();
    }
}
