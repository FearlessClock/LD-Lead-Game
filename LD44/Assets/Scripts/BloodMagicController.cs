using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMagicController : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    private PassiveBloodMagic passiveBloodMagic;
    private ActiveBloodMagic activeBloodMagic;

    private void Awake()
    {
        passiveBloodMagic = GetComponent<PassiveBloodMagic>();
        activeBloodMagic = GetComponent<ActiveBloodMagic>();
        UsePassiveBloodMagic();
    }

    private void UsePassiveBloodMagic()
    {
        passiveBloodMagic.CastMagic();
    }

    public void CastBloodMagic()
    {
        activeBloodMagic.CastMagic();
        healthController.TakeDamage(activeBloodMagic.GetBloodCost());
    }

    public void SetActiveMagic(ActiveBloodMagic item)
    {
        activeBloodMagic.DestroyComponent();
        item.AddComponent(this.gameObject);
    }

    public void SetPassiveMagic(PassiveBloodMagic item)
    {
        passiveBloodMagic.DestroyComponent();
        item.AddComponent(this.gameObject);
    }
}
