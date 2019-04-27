using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float yAxisMovementModifier;

    [SerializeField] private HitBoxController hitBoxController;

    [SerializeField] private float cooldownTime;

    private int facing;
    private float cooldownTimer;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cooldownTimer = cooldownTime;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * yAxisMovementModifier, Input.GetAxisRaw("Vertical"));
        if(movement.x < 0)
        {
            facing = 180;
        }
        else if(movement.x > 0)
        {
            facing = 0;
        }
        Debug.Log(facing + " " + Quaternion.Euler(0, facing, 0));
        rb.MovePosition(this.transform.position + movement * movementSpeed * Time.fixedDeltaTime);
        this.transform.rotation = (Quaternion.Euler(0, facing, 0));

        cooldownTimer -= Time.fixedDeltaTime;
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            GameObject[] hits = hitBoxController.Hit();
            foreach (GameObject enemy in hits)
            {
                HealthController hc = enemy.GetComponent<HealthController>();
                if (hc)
                {
                    hc.TakeDamage(1);
                }
            }
            cooldownTimer = cooldownTime;
        }
    }
}
