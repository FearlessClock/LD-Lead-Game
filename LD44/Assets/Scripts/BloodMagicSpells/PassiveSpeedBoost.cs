using UnityEngine;
using System.Collections;

public class PassiveSpeedBoost : MonoBehaviour, PassiveBloodMagic
{
    [SerializeField] private FloatVariable characterSpeed;
    [SerializeField] private float speedBoost;

    void PassiveBloodMagic.CastMagic()
    {
        characterSpeed.SetValue(characterSpeed * speedBoost);
    }

    float PassiveBloodMagic.GetBloodCost()
    {
        return 0;
    }
}
