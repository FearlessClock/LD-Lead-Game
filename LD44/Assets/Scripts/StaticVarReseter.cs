using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResetFloatValue
{
    public FloatVariable value;
    public float startingValue;
}

[System.Serializable]
public class ResetIntValue
{
    public IntVariable value;
    public int startingValue;
}

public class StaticVarReseter : MonoBehaviour
{
    [SerializeField] private bool reset;
    [SerializeField] private ResetFloatValue[] floatResetValues;
    [SerializeField] private ResetIntValue[] intResetValues;

    private void Awake()
    {
        foreach (ResetFloatValue var in floatResetValues)
        {
            var.value.SetValue(var.startingValue);
        }
        foreach (ResetIntValue var in intResetValues)
        {
            var.value.SetValue(var.startingValue);
        }
    }
}
