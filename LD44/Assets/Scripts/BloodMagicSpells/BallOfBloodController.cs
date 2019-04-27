using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(HitBoxController), typeof(SendToPool))]
public class BallOfBloodController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private SendToPool sendToPool;
    private HitBoxController hitBoxController;
    public Vector3 fireDirection;
    private Rigidbody2D rb;
    private void Awake()
    {
        hitBoxController = GetComponent<HitBoxController>();
        rb = GetComponent<Rigidbody2D>();
        this.transform.right = fireDirection;
    }

    void FixedUpdate()
    {
        GameObject[] hits = hitBoxController.Hit();
        if (hits.Length > 0)
        {
            foreach (GameObject obj in hits)
            {
                if (obj.CompareTag("Player"))
                {
                    continue;
                }
                HealthController healthController = obj.GetComponent<HealthController>();
                if (healthController)
                {
                    healthController.TakeDamage(damage);
                }
            }

            sendToPool.SendBackToPool(this.gameObject);
        }
        rb.MovePosition(this.transform.position + fireDirection * speed * Time.fixedDeltaTime);
    }
}
