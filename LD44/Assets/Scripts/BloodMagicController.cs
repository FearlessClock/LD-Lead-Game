using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMagicController : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    private PassiveBloodMagic[] passiveBloodMagic;
    private ActiveBloodMagic activeBloodMagic;

    private void Awake()
    {
        passiveBloodMagic = GetComponents<PassiveBloodMagic>();
        activeBloodMagic = GetComponent<ActiveBloodMagic>();
        UsePassiveBloodMagic();
    }

    private void UsePassiveBloodMagic()
    {
        foreach (PassiveBloodMagic magic in passiveBloodMagic)
        {
            magic.CastMagic();
        }
    }

    public void CastBloodMagic()
    {
        activeBloodMagic.CastMagic();
        healthController.TakeDamage(activeBloodMagic.GetBloodCost());
    }
}
