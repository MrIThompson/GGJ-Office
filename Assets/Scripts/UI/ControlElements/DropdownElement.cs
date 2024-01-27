using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownElement : ControlElement
{
    [SerializeField] private TMP_Dropdown _dropdown;
    
    public override void InitChild()
    {
        _dropdown.options = new List<TMP_Dropdown.OptionData>();
        _dropdown.options.Add(new TMP_Dropdown.OptionData("0"));
        _dropdown.options.Add(new TMP_Dropdown.OptionData("0.25"));
        _dropdown.options.Add(new TMP_Dropdown.OptionData("0.5"));
        _dropdown.options.Add(new TMP_Dropdown.OptionData("0.75"));
        _dropdown.options.Add(new TMP_Dropdown.OptionData("1"));
        int r = Random.Range(0, 5);
        _dropdown.options[r].text = Target.ToString();
        base.InitChild();
    }

    public void SubmitInt(int i)
    {
        var f = float.Parse(_dropdown.options[i].text);
        base.SubmitFloat(f);
    }
}
