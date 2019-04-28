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

    [SerializeField] private ParticlePlayer particlePlayer;
    
    private bool isAttacking;

    private int facing;
    private float weakAttackCooldownTimer;
    private float strongAttackCooldownTimer;
    private float CastMagicCooldownTimer;

    private Rigidbody2D rb;

    public UnityEvent OnLaunchWeakAttack;
    public UnityEvent OnWeakAttackLand;
    public UnityEvent OnLaunchStrongAttack;
    public UnityEvent OnStrongAttackLand;
    public UnityEvent OnLaunchBloodMagic;

    private void Awake()
    {
        particlePlayer.Stop();
        movementSpeed.SetValue(movementSpeedBase);
        rb = GetComponent<Rigidbody2D>(); 
        weakAttackCooldownTimer = cooldownWeakAttackTime;
        strongAttackCooldownTimer = cooldownStrongAttackTime;
        CastMagicCooldownTimer = cooldownMagicCastTime;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(input.GetXAxis, 0, input.GetYAxis * yAxisMovementModifier);
        facing = CalculateFacing(movement, facing);

        float speedX = Mathf.Abs(movement.x);
        float speedY = Mathf.Abs(movement.z);
        animator.SetFloat("Speed", speedX);
        if(speedX > 0 || speedY > 0)
        {
            particlePlayer.Play();
        }
        else if(speedX <= 0 && speedY <=0)
        {
            particlePlayer.Stop();
        }

        Vector3 projectedMovement = new Vector3(movement.x, movement.z + movement.y, movement.z);
        rb.MovePosition(this.transform.position + projectedMovement * movementSpeed * Time.fixedDeltaTime);
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
        bool hitLanded = false;
        GameObject[] hits = hitBoxController.Hit();
        foreach (GameObject enemy in hits)
        {
            HealthController hc = enemy.GetComponent<HealthController>();
            if (hc)
            {
                hc.TakeDamage(attackDamage);
                hitLanded = true;
            }
        }
        if (hitLanded)
        {
            OnWeakAttackLand?.Invoke();
        }
        weakAttackCooldownTimer = cooldownWeakAttackTime;
    }

    public void ThrowStrongAttack()
    {
        bool hitLanded = false;
        GameObject[] hits = hitBoxController.Hit();
        foreach (GameObject enemy in hits)
        {
            HealthController hc = enemy.GetComponent<HealthController>();
            if (hc)
            {
                hc.TakeDamage(attackDamage);
                hitLanded = true;
            }
        }
        if (hitLanded)
        {
            OnWeakAttackLand?.Invoke();
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
