using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/InputVariable", order = 0)]
public class InputVariable : ScriptableObject
{
    public string xAxis;
    public string yAxis;
    public string attackWeak;
    public string attackStrong;
    public string castBloodMagic;
    public string jump;

    public float GetXAxis
    {
        get { return Input.GetAxisRaw(xAxis); }
    }
    public float GetYAxis
    {
        get { return Input.GetAxisRaw(yAxis); }
    }

    public bool IsAttackWeakPressed
    {
        get { return Input.GetButtonDown(attackWeak); }
    }
    public bool IsAttackStrongPressed
    {
        get { return Input.GetButtonDown(attackStrong); }
    }
    public bool IsCastingBloodMagic
    {
        get { return Input.GetButtonDown(castBloodMagic); }
    }
    public bool IsJumpPressed
    {
        get { return Input.GetButtonDown(jump); }
    }
    
}
