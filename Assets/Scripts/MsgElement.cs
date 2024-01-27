using TMPro;
using UnityEngine;

public class MsgElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _txt;
    [SerializeField] private GameObject _playerBg;
    [SerializeField] private GameObject _customerBg;

    public void Init(string txt, bool player)
    {
        _txt.SetText(txt);
        _playerBg.SetActive(player);
        _customerBg.SetActive(!player);
    }
}
