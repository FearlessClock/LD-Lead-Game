using UnityEngine;
using System.Collections;

public abstract class aAttack : MonoBehaviour
{
    [SerializeField] protected float attackDamage;
    abstract public void Attack(HitBoxController hitBoxController);
}
