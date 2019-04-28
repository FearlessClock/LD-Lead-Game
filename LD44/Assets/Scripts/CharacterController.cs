using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float movementSpeedBase;
    [SerializeField] private FloatVariable movementSpeed;
    [SerializeField] private float yAxisMovementModifier;
    
    [SerializeField] private FloatVariable attackDamage;

    [SerializeField] private InputVariable input;

    [SerializeField] private Animator animator;

    [SerializeField] private ParticlePlayer particlePlayer;

    [SerializeField] private ItemsController itemController;
    
    private bool isAttacking;

    private int facing;

    private Rigidbody2D rb;

    public UnityEvent OnLaunchWeakAttack;
    public UnityEvent OnWeakAttackLand;
    public UnityEvent OnLaunchStrongAttack;
    public UnityEvent OnStrongAttackLand;
    public UnityEvent OnLaunchBloodMagic;

    public void SetItemController(ItemsController ic)
    {
        itemController = ic;
    }

    private void Awake()
    {
        particlePlayer.Stop();
        movementSpeed.SetValue(movementSpeedBase);
        rb = GetComponent<Rigidbody2D>();
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

        if (!isAttacking)
        {
            isAttacking = true;
            if (input.IsAttackWeakPressed)
            {
                OnLaunchWeakAttack?.Invoke();
                ThrowWeakAttack();
            }else if (input.IsAttackStrongPressed)
            {
                OnLaunchStrongAttack?.Invoke();
                ThrowStrongAttack();
            }
            else if (input.IsCastingBloodMagic)
            {
                OnLaunchBloodMagic?.Invoke();
                CastBloodMagic();
            }
            else
            {
                isAttacking = false;
            }
        }
    }

    public void OnAttackFinished()
    {
        isAttacking = false;
    }

    public void ThrowWeakAttack()
    {
        bool landed = itemController.ThrowWeakAttack();
        if (landed)
        {
            OnWeakAttackLand?.Invoke();
        }
    }

    public void ThrowStrongAttack()
    {
        bool landed = itemController.ThrowStrongAttack();
        if (landed)
        {
            OnStrongAttackLand?.Invoke();
        }
    }

    public void CastBloodMagic()
    {
        itemController.CastBloodMagic();
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
