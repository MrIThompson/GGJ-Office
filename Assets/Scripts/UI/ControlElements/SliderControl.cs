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
        CurrentAmount = setCurrent();

        _amountText.SetText(CurrentAmount.ToString("0.00"));
        _slider.value = CurrentAmount;
        _slider.maxValue = 1;
        base.InitChild();
    }

    public override void SubmitFloat(float i)
    {
        base.SubmitFloat(i);
        _amountText.SetText(CurrentAmount.ToString("0.00"));
    }

    private float setCurrent()
    {
        float v = Random.value;
        bool ready = false;

        while (!ready)
        {
            v = Random.value;

            print(v);

            if (Mathf.Abs(v - Target) < 0.2)
            {
                ready = true;
            }
        }

        print("returning " + v + "VS" + Target);
        return v;



    }
}
