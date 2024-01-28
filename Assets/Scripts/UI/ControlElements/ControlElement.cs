using System;
using TMPro;
using UnityEngine;

public class ControlElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    public string ProblemId;
    public float CurrentAmount;
    public float Target;
    public Action<string,float> FloatEvent;
    
    public void Init(string title, float target)
    {
        ProblemId = title;
        _titleText.SetText(title);
        Target = target;
        InitChild();
    }

    public virtual void InitChild()
    {
        
    }
    
    public virtual void SubmitFloat(float i)
    {
        CurrentAmount = i;
        FloatEvent?.Invoke(ProblemId, i);
    }
    
}
