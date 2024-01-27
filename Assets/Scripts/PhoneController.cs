using System;
using DG.Tweening;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
   public GameController GameController;
   [SerializeField] private Transform _phoneTransform;
   [SerializeField] private AudioSource _ringSfx;
   [SerializeField] private GameObject _phoneRingObj;
   private bool _onPhone;
   private Sequence _animationSeq;
   
   public void AnswerPhone()
   {
      if (_onPhone) return;
      _onPhone = true;
      _animationSeq.Kill();
      _ringSfx.Stop();
      GameController.BeginCall();
   }

   public void EndCall()
   {
      _onPhone = false;
      _phoneRingObj.SetActive(false);
   }

   public void StartPhoneCall()
   {
      _ringSfx.Play();
      _animationSeq = DOTween.Sequence();
      _animationSeq.Append(_phoneTransform.DOPunchRotation(Vector3.one, 2, 8));
      _animationSeq.SetDelay(0.5f).SetLoops(-1);
      _animationSeq.Play();
      _phoneRingObj.SetActive(true);
   }

   private void Update()
   {
      if (_onPhone) return;
      if(Input.GetMouseButtonDown(0))
      {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out hit))
         {
            if(hit.transform == this.transform) AnswerPhone();
         }
      }
   }
}
