using TMPro;
using UnityEngine;

public class ControlElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    public float CurrentAmount;
    public float Target;
    
    public void Init(string title, float target)
    {
        _titleText.SetText(title);
        Target = target;
        InitChild();
    }

    public virtual void InitChild()
    {
        Debug.Log("Control surface init");
    }
    
    public virtual void SubmitFloat(float i)
    {
        CurrentAmount = i;
    }
    
}
