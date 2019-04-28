using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public abstract class aAttack : MonoBehaviour
{
    [SerializeField] protected float attackDamage;
    public UnityEvent OnAttackThrow;
    public UnityEvent OnAttackLand;
    abstract public void Attack(HitBoxController hitBoxController);
}
