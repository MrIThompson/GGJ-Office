using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerUiController : MonoBehaviour
{
    [Header("Toolbar")] 
    [SerializeField] private TMP_Text _timeText;

    [Header("Manual")] 
    [SerializeField] private GameObject _manualParent;
    
    [Header("Remote")]
    [SerializeField] private GameObject _remoteParent;

    [Header("Notifications")] 
    [SerializeField] private RectTransform _notifParent;
    [SerializeField] private NotifElement _notifPrefab;
    [SerializeField] private float _notifExpireTime;
    [SerializeField] private float _notifSpawnTime;

    private void Start()
    {
        UpdateTimer();
        _manualParent.SetActive(false);
        _remoteParent.SetActive(false);
        Invoke(nameof(CheckNotif), _notifSpawnTime);
    }

    private void UpdateTimer()
    {
        _timeText.SetText(System.DateTime.Now.ToString("t"));
        Invoke(nameof(UpdateTimer), 1);
    }

    private void CheckNotif()
    {
        var obj = Instantiate(_notifPrefab, _notifParent);
        obj.Init("", _notifExpireTime);
        Invoke(nameof(CheckNotif), _notifSpawnTime);
    }
    
    public void OpenManual()
    {
        _manualParent.SetActive(true);
        _remoteParent.SetActive(false);
    }

    public void OpenRemote()
    {
        _remoteParent.SetActive(true);
        _manualParent.SetActive(false);
    }
    
}
