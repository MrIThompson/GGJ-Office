using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class PhoneController : MonoBehaviour
{
   public GameController GameController;
   [SerializeField] private Transform _phoneTransform;
   [SerializeField] private AudioSource _ringSfx;
   [SerializeField] private GameObject _phoneRingObj;
   private bool _onPhone;
   private Sequence _animationSeq;

   [SerializeField] private RectTransform _msgParent;
   [SerializeField] private MsgElement _msg;
   private List<MsgElement> _msgList = new List<MsgElement>();
   private Ticket _currentTicket;
   private int _problemIndex; 
   private int _cannedIndex; 
   private int _wrongIndex; 
   private int _rightIndex;

   [SerializeField] private string[] _playerResponses;
   
   public void AnswerPhone()
   {
      if (_onPhone) return;
      _onPhone = true;
      _animationSeq.Kill();
      _ringSfx.Stop();
      GameController.BeginCall();
   }

   public void PlayerResponse()
   {
      DisplayMsg(_playerResponses[Random.Range(0,_playerResponses.Length)], true);
   }

   public void StartPhoneConvo(Ticket ticket)
   {
      _currentTicket = ticket;
      DisplayProblem();
   }

   private void DisplayProblem()
   {
      DisplayMsg(_currentTicket.problem[_problemIndex], false);
      _problemIndex++;
      float r = Random.Range(0.5f, 2);
      Invoke(nameof(PlayerResponse), r);
      if (_problemIndex < _currentTicket.problem.Length)
      {
         Invoke(nameof(DisplayProblem), r+1f);
      }
      else
      {
         Invoke(nameof(StartIrritationCountdown), r+3f);
      }
   }

   private void StartIrritationCountdown()
   {
      DisplayMsg(_currentTicket.cannedResponses[_cannedIndex], false);
      _cannedIndex++;
      if (_cannedIndex < _currentTicket.cannedResponses.Length)
      {
         Invoke(nameof(StartIrritationCountdown), Random.Range(5,10));
      }
   }

   public void SuccessText()
   {
      if (_rightIndex >= _currentTicket.successText.Length) return;
      DisplayMsg(_currentTicket.successText[_rightIndex], false);
      _rightIndex++;
   }
   
   public void FailText()
   {
      if (_wrongIndex >= _currentTicket.failureText.Length) return;
      DisplayMsg(_currentTicket.failureText[_wrongIndex], false);
      _wrongIndex++;
   }

   private void DisplayMsg(string msg, bool player)
   {
      var obj = Instantiate(_msg, _msgParent); 
      obj.Init(msg, player);
      _msgList.Add(obj);
   }
   
   public void CompleteCall()
   {
      CancelInvoke();
      SuccessText();
      Invoke(nameof(EndCall),3);
   }
   
   public void EndCall()
   {
      _onPhone = false;
      _phoneRingObj.SetActive(false);
      _problemIndex = 0;
      _cannedIndex = 0;
      _wrongIndex = 0;
      _rightIndex = 0;
      foreach (var msg in _msgList)
      {
         msg.Clear();
      }

      _msgList = new List<MsgElement>();
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
