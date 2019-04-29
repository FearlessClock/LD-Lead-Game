using UnityEngine;
using System.Collections;

public interface ActiveBloodMagic
{
    float GetBloodCost();
    void DestroyComponent();
    void AddComponent(GameObject obj);
    void CastMagic();
}
