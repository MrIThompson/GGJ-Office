using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInputControl : ControlElement
{
    public void SubmitText(string txt)
    {
        var parsed = float.Parse(txt);
        if (parsed != null)
        {
            base.SubmitFloat(parsed);
        }
    }
}
