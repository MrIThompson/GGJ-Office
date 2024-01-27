using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifElement : MonoBehaviour
{
   [SerializeField] private Image _iconImage;
   [SerializeField] private TMP_Text _txtDesc;
   [SerializeField] private CanvasGroup _group;
   public void Init(string txt, float time)
   {
      _group.DOFade(1, 1);
      transform.DOShakePosition(1, Vector3.left*10);
      _txtDesc.SetText(txt);
      Invoke(nameof(DestroyObj), time);
   }

   private void DestroyObj()
   {
      _group.DOFade(0, 1).OnComplete(()=>Destroy(gameObject));
   }
}
