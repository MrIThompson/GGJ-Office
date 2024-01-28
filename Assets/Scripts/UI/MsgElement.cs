using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MsgElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _txt;
    [SerializeField] private Image _playerBg;
    [SerializeField] private Image _customerBg;
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] private Color _standardColour;
    [SerializeField] private Color _badColour;
    [SerializeField] private Color _goodColour;

    public enum colour
    {
        normal,
        good,
        bad
    }
    
    public void Init(string txt, bool player, colour colour)
    {
        _playerBg.gameObject.SetActive(player);
        _playerBg.color = _standardColour;
        _customerBg.gameObject.SetActive(!player);
        _customerBg.color = _standardColour;
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, 1);
        _txt.SetText(txt);
        switch (colour)
        {
            case colour.normal:
                break;
            case colour.good:
                _customerBg.DOColor(_goodColour, 1);
                break;
            case colour.bad:
                _customerBg.DOColor(_badColour, 1);
                break;
        }
    }

    public void Clear()
    {
        _canvasGroup.DOFade(0, 0.5f).OnComplete(() => Destroy(gameObject));
        
    }
}
