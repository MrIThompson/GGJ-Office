using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SensitiveButtonControl : ControlElement
{
    [SerializeField] private TMP_Text _amount;

    public override void InitChild()
    {
        CurrentAmount = 0;
        _amount.SetText("000");
        base.InitChild();
    }

    public void HoldDownButton()
    {
        CurrentAmount += 0.01f;
        _amount.SetText(CurrentAmount.ToString());
    }

    public void LetGoButton()
    {
        SubmitFloat(CurrentAmount);
        if(Math.Abs(CurrentAmount - Target) > 0.01f) CurrentAmount = 0;
        _amount.SetText(CurrentAmount.ToString());
    }
}
