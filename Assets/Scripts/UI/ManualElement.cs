using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManualElement : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _body;

    public void Init(Sprite img, string title, string body)
    {
        _image.sprite = img;
        _title.SetText(title);
        _body.SetText(body);
    }
}
