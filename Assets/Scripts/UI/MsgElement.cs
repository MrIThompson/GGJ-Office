using DG.Tweening;
using TMPro;
using UnityEngine;

public class MsgElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _txt;
    [SerializeField] private GameObject _playerBg;
    [SerializeField] private GameObject _customerBg;
    [SerializeField] private CanvasGroup _canvasGroup;
    
    public void Init(string txt, bool player)
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, 1);
        _txt.SetText(txt);
        _playerBg.SetActive(player);
        _customerBg.SetActive(!player);
    }

    public void Clear()
    {
        _canvasGroup.DOFade(0, 0.5f);
        Destroy(gameObject);
    }
}
