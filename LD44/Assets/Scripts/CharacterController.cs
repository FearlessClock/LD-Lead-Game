using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(HitBoxController), typeof(BloodMagicController))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float movementSpeedBase;
    [SerializeField] private FloatVariable movementSpeed;
    [SerializeField] private float yAxisMovementModifier;

    [SerializeField] private HitBoxController hitBoxController;
    [SerializeField] private BloodMagicController bloodMagicController;

    [SerializeField] private float cooldownWeakAttackTime;
    [SerializeField] private float cooldownStrongAttackTime;
    [SerializeField] private float cooldownMagicCastTime;
    
    [SerializeField] private float attackDamage;

    [SerializeField] private InputVariable input;

    [SerializeField] private Animator animator;
    private bool isAttacking;

    private int facing;
    private float weakAttackCooldownTimer;
    private float strongAttackCooldownTimer;
    private float CastMagicCooldownTimer;

    private Rigidbody2D rb;

    public UnityEvent OnLaunchWeakAttack;
    public UnityEvent OnLaunchStrongAttack;
    public UnityEvent OnLaunchBloodMagic;

    private void Awake()
    {
        movementSpeed.SetValue(movementSpeedBase);
        rb = GetComponent<Rigidbody2D>(); 
        weakAttackCooldownTimer = cooldownWeakAttackTime;
        strongAttackCooldownTimer = cooldownStrongAttackTime;
        CastMagicCooldownTimer = cooldownMagicCastTime;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(input.GetXAxis, input.GetYAxis * yAxisMovementModifier);
        facing = CalculateFacing(movement, facing);

        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        rb.MovePosition(this.transform.position + movement * movementSpeed * Time.fixedDeltaTime);
        this.transform.rotation = (Quaternion.Euler(0, facing, 0));

        weakAttackCooldownTimer -= Time.fixedDeltaTime;
        strongAttackCooldownTimer -= Time.fixedDeltaTime;
        CastMagicCooldownTimer -= Time.fixedDeltaTime;

        if (!isAttacking && input.IsAttackWeakPressed)
        {
            isAttacking = true;
            OnLaunchWeakAttack?.Invoke();
            ThrowWeakAttack();
        }
        if (!isAttacking && input.IsAttackStrongPressed)
        {
            isAttacking = true;
            OnLaunchStrongAttack?.Invoke();
            ThrowStrongAttack();
        }
        if (!isAttacking && input.IsCastingBloodMagic)
        {
            isAttacking = true;
            OnLaunchBloodMagic?.Invoke();
            CastBloodMagic();
        }
    }

    public void OnAttackFinished()
    {
        isAttacking = false;
    }

    public void ThrowWeakAttack()
    {
        GameObject[] hits = hitBoxController.Hit();
        foreach (GameObject enemy in hits)
        {
            HealthController hc = enemy.GetComponent<HealthController>();
            if (hc)
            {
                hc.TakeDamage(attackDamage);
            }
        }
        weakAttackCooldownTimer = cooldownWeakAttackTime;
    }

    public void ThrowStrongAttack()
    {
        GameObject[] hits = hitBoxController.Hit();
        foreach (GameObject enemy in hits)
        {
            HealthController hc = enemy.GetComponent<HealthController>();
            if (hc)
            {
                hc.TakeDamage(attackDamage);
            }
        }
        strongAttackCooldownTimer = cooldownStrongAttackTime;
    }

    public void CastBloodMagic()
    {
        bloodMagicController.CastBloodMagic();
        CastMagicCooldownTimer = cooldownMagicCastTime;
    }

    private int CalculateFacing(Vector3 movement, int oldFacing)
    {
        if (movement.x < 0)
        {
            return 180;
        }
        else if (movement.x > 0)
        {
            return 0;
        }
        return oldFacing;
    }
}
