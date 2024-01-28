using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderControl : ControlElement
{
   [SerializeField] private TMP_Text _amountText;
   [SerializeField] private Slider _slider;
   
   public override void InitChild()
   {
      CurrentAmount = Random.value;
      _amountText.SetText(CurrentAmount.ToString());
      _slider.value = CurrentAmount;
      _slider.maxValue = 1;
      base.InitChild();
   }
   
   public override void SubmitFloat(float i)
   {
      base.SubmitFloat(i);
      _amountText.SetText(CurrentAmount.ToString());
   }
}
