using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComputerUiController : MonoBehaviour
{
    [SerializeField] private Canvas _parentCanvas;
    [SerializeField] private RectTransform _cursorRect;

    [Header("Toolbar")]
    [SerializeField] private TMP_Text _timeText;

    [Header("Manual")]
    [SerializeField] private GameObject _manualParent;
    [SerializeField] private ManualElement _manualElement;
    [SerializeField] private ManualElement _manualWarningElement;

    [Header("Remote")]
    [SerializeField] private GameObject _remoteParent;
    [SerializeField] private TMP_Text _customerNameText;
    [SerializeField] private ControlGroupController[] _controllers;

    [Header("Notifications")]
    [SerializeField] private RectTransform _notifParent;
    [SerializeField] private NotifElement _notifPrefab;
    [SerializeField] private float _notifExpireTime;
    [SerializeField] private float _notifSpawnTime;

    int UILayer;

    EmailParser emailParser;

    private void Start()
    {
        UILayer = LayerMask.NameToLayer("UI");
        emailParser = GetComponent<EmailParser>();
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
        string notifText = emailParser.getEmail();
        var obj = Instantiate(_notifPrefab, _notifParent);
        obj.Init(notifText, _notifExpireTime);
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

    private void Update()
    {
        Cursor.visible = !IsPointerOverUIElement();
        if (!IsPointerOverUIElement()) return;
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _parentCanvas.transform as RectTransform,
            Input.mousePosition, _parentCanvas.worldCamera,
            out movePos);

        Vector3 mousePos = _parentCanvas.transform.TransformPoint(movePos);
        _cursorRect.transform.position = mousePos;
    }

    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer && curRaysastResult.gameObject == this.gameObject)
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
