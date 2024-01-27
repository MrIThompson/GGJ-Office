using UnityEngine;
using UnityEngine.UI;

public class ToggleControl : ControlElement
{
    [SerializeField] private Toggle _toggle;
    
    public override void InitChild()
    {
        // if (Target == 1) _toggle.isOn = false;
        // else _toggle.isOn = true;
        _toggle.SetIsOnWithoutNotify(Target!=1);
        base.InitChild();
    }
   
    public override void SubmitFloat(float i)
    {
        base.SubmitFloat(_toggle.isOn ? 1 : 0);
    }
}
