using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PhoneController : MonoBehaviour
{
    public GameController GameController;
    public AudioController audioController;
    [SerializeField] private Transform _phoneTransform;
    [SerializeField] private GameObject _phoneRingObj;
    private bool _onPhone;
    private Sequence _animationSeq;

    [SerializeField] private RectTransform _msgParent;
    [SerializeField] private MsgElement _msg;
    private List<MsgElement> _msgList = new List<MsgElement>();
    private Ticket _currentTicket;
    private int _problemIndex;
    private int _timeOutCounter;
    public int TimeOut;

    [SerializeField] private string[] _playerResponses;

    public void AnswerPhone()
    {
        if (_onPhone) return;
        _onPhone = true;
        _animationSeq.Kill();
        audioController.StopAudio(Sfx.ring);
        GameController.BeginCall();
    }

    public void PlayerResponse()
    {
        DisplayMsg(_playerResponses[Random.Range(0, _playerResponses.Length)], true, MsgElement.colour.normal);
    }

    public void StartPhoneConvo(Ticket ticket)
    {
        _animationSeq.Kill();
        audioController.StopAudio(Sfx.ring);
        _currentTicket = ticket;
        DisplayProblem();
    }

    private void DisplayProblem()
    {
        DisplayMsg(_currentTicket.problem[_problemIndex], false, MsgElement.colour.normal);
        _problemIndex++;
        float r = Random.Range(3f, 6f);
        Invoke(nameof(PlayerResponse), r);
        if (_problemIndex < _currentTicket.problem.Length)
        {
            Invoke(nameof(DisplayProblem), r + 2f);
        }
        else
        {
            Invoke(nameof(StartIrritationCountdown), r + 3f);
        }

        audioController.PlayAudio(Random.value < 0.5f ? Sfx.voice1 : Sfx.voice2);
    }

    private void StartIrritationCountdown()
    {
        DisplayMsg(_currentTicket.cannedResponses[Random.Range(0, _currentTicket.cannedResponses.Length)], false, MsgElement.colour.normal);
        _timeOutCounter++;
        audioController.PlayAudio(Random.value < 0.5f ? Sfx.voice1 : Sfx.voice2);
        if (_timeOutCounter < TimeOut)
        {
            Invoke(nameof(StartIrritationCountdown), Random.Range(5, 10));
        }
        else
        {
            GameController.CompleteCall(false);
        }
    }

    public void SuccessText()
    {
        DisplayMsg(_currentTicket.successText[Random.Range(0, _currentTicket.successText.Length)], false, MsgElement.colour.good);
        audioController.PlayAudio(Random.value < 0.5f ? Sfx.voice1 : Sfx.voice2);
    }

    public void FailText()
    {
        audioController.PlayAudio(Sfx.angvoice);
        DisplayMsg(_currentTicket.failureText[Random.Range(0, _currentTicket.failureText.Length)], false, MsgElement.colour.bad);
    }

    private void DisplayMsg(string msg, bool player, MsgElement.colour colour)
    {
        var obj = Instantiate(_msg, _msgParent);
        obj.Init(msg, player, colour);
        _msgList.Add(obj);
    }

    public void CompleteCall(bool win)
    {
        CancelInvoke();
        if (win) SuccessText();
        else FailText();
        Invoke(nameof(EndCall), 3);
    }

    public void EndCall()
    {
        audioController.StopAudio(Sfx.voice1);
        audioController.StopAudio(Sfx.voice2);
        audioController.StopAudio(Sfx.angvoice);
        audioController.PlayAudio(Sfx.hangup);
        _onPhone = false;
        _phoneRingObj.SetActive(false);
        _problemIndex = 0;
        _timeOutCounter = 0;
        foreach (var msg in _msgList)
        {
            msg.Clear();
        }

        _msgList = new List<MsgElement>();
    }

    public void StartPhoneCall()
    {
        audioController.StopAudio(Sfx.hangup);
        audioController.PlayAudio(Sfx.ring);
        _animationSeq = DOTween.Sequence();
        _animationSeq.Append(_phoneTransform.DOPunchRotation(Vector3.one, 2, 8));
        _animationSeq.SetDelay(0.5f).SetLoops(-1);
        _animationSeq.Play();
        _phoneRingObj.SetActive(true);
    }

    private void Update()
    {
        if (_onPhone) return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform) AnswerPhone();
            }
        }
    }
}
