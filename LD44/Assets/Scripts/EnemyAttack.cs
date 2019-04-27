using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private CharacterController player;
    private HitBoxController hitBoxController;
    [SerializeField] private aAttack weakAttack;
    [SerializeField] private aAttack strongAttack;

    private void Awake()
    {
        hitBoxController = GetComponent<HitBoxController>();
        player = FindObjectOfType<CharacterController>();
    }

    public void OnStrongAttack()
    {
        strongAttack.Attack(hitBoxController);
    }

    public void OnWeakAttack()
    {
        weakAttack.Attack(hitBoxController);
    }
}
