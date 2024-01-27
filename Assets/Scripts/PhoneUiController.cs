using System.Collections.Generic;
using UnityEngine;

public class PhoneUiController : MonoBehaviour
{
    [SerializeField] private MsgElement _msgElement;
    [SerializeField] private RectTransform _msgParent;
    private List<MsgElement> _msgList = new List<MsgElement>();

    [SerializeField] private string[] _playerResponses;
    
    public void AnswerPhone()
    {
        
    }
    
    public void Yes()
    {
        //post response 
        var msg = Instantiate(_msgElement, _msgParent);
        msg.Init(_playerResponses[Random.Range(0,_playerResponses.Length)], true);
        _msgList.Add(msg);
    }

    public void HangUp()
    {
        foreach (var msg in _msgList)
        {
            Destroy(msg);
        }
        _msgList = new List<MsgElement>();
    }
}
