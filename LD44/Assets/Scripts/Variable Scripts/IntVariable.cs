using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class IntEvent : UnityEvent<float> {}
[CreateAssetMenu(fileName = "New int Variable", menuName = "Variables/IntVariable", order = 1)]
public class IntVariable : ScriptableObject
{
    public int value;
    public IntEvent OnValueChanged;
    public static implicit operator int(IntVariable reference)
    {
        return reference.value;
    }

    public void SetValue(int v)
    {
        this.value = v;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}
