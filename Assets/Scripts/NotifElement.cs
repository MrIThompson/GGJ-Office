using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifElement : MonoBehaviour
{
   [SerializeField] private Image _iconImage;
   [SerializeField] private TMP_Text _txtDesc;

   public void Init(string txt, float time)
   {
      _txtDesc.SetText(txt);
      Invoke(nameof(DestroyObj), time);
   }

   private void DestroyObj()
   {
      Destroy(gameObject);
   }
}
