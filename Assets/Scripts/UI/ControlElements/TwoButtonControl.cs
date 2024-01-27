using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TwoButtonControl : ControlElement
{
    [SerializeField] private TMP_Text _amount;
    
    public override void InitChild()
    {
        _amount.SetText(CurrentAmount.ToString());
        base.InitChild();
    }

    public void Up()
    {
        CurrentAmount += 0.01f;
        _amount.SetText(CurrentAmount.ToString());
        SubmitFloat(CurrentAmount);
    }

    public void Down()
    {
        CurrentAmount -= 0.01f;
        _amount.SetText(CurrentAmount.ToString());
        SubmitFloat(CurrentAmount);
    }
}
