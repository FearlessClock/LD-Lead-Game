using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
public class Weapon : Item
{
	public int damageOnWeakAttack;
	public int damageOnStrongAttack;
	public float cooldownOnWeakAttack;
	public float cooldownOnStrongAttack;

	// TODO : How do you want to handle scripting for those
}
