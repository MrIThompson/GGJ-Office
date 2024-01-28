using System;
using TMPro;
using UnityEngine;

public class SensitiveButtonControl : ControlElement
{
    [SerializeField] private TMP_Text _amount;
    private bool _held;
    
    public override void InitChild()
    {
        CurrentAmount = 0;
        _amount.SetText("000");
        base.InitChild();
    }

    public void HoldDownButton()
    {
        _held = true;
    }

    public void LetGoButton()
    {
        _held = false;
        SubmitFloat(CurrentAmount);
        if(Math.Abs(CurrentAmount - Target) > 0.01f) CurrentAmount = 0;
        _amount.SetText(CurrentAmount.ToString());
    }

    private void Update()
    {
        if (!_held) return; 
        CurrentAmount += 0.01f;
        _amount.SetText(CurrentAmount.ToString());
    }
}
