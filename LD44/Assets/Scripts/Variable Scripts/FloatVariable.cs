using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class FloatEvent : UnityEvent<float> {}
[CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/FloatVariable", order = 0)]
public class FloatVariable : ScriptableObject
{
    public float value;
    public FloatEvent OnValueChanged;
    public static implicit operator float(FloatVariable reference)
    {
        return reference.value;
    }

    public void SetValue(float v)
    {
        this.value = v;
        OnValueChanged?.Invoke(v);
    }

    public override string ToString()
    {
        return value.ToString();
    }
}
