using UnityEngine;
using System.Collections;

public interface PassiveBloodMagic
{
    float GetBloodCost();
    void DestroyComponent();
    void AddComponent(GameObject obj);
    void CastMagic();
}
