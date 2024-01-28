using TMPro;
using UnityEngine;

public class MultiButtonControl : ControlElement
{
   [SerializeField] private TMP_Text[] _buttonText;
   private int r; 
   
   public override void InitChild()
   {
      foreach (TMP_Text txt in _buttonText)
      {
         txt.SetText(Random.Range(0f,1f).ToString("0.00"));
      }
      r = Random.Range(0, _buttonText.Length);
      _buttonText[r].SetText(Target.ToString("0.00"));
      base.InitChild();
   }

   public void PressButton(int i)
   {
      if (r == i) SubmitFloat(Target);
   }
}
