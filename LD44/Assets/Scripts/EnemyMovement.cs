using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float minDistance;
    private int facing;
    private Rigidbody2D rb;
    private CharacterController player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<CharacterController>();
    } 

    public void MoveToPlayer()
    {
        Vector3 playerPos = player.transform.position;

        if(Distance(playerPos, this.transform.position) > minDistance * minDistance)
        {
            Vector3 direction = (playerPos - this.transform.position).normalized;
            facing = CalculateFacing(direction, facing);
            rb.MovePosition(this.transform.position + direction * movementSpeed * Time.fixedDeltaTime);
            this.transform.rotation = (Quaternion.Euler(0, facing, 0));
        }
    }

    private int CalculateFacing(Vector3 movement, int oldFacing)
    {
        if (movement.x < 0)
        {
            return 0;
        }
        else if (movement.x > 0)
        {
            return 180;
        }
        return oldFacing;
    }

    private float Distance(Vector3 a, Vector3 b)
    {
        return Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, minDistance);
    }
}
