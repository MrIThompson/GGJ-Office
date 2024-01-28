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
    [SerializeField] private ControlElement[] _elements;
    [SerializeField] private string[] _problems;
    
    
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

    public void SetRemote(Ticket ticket)
    {
        _customerNameText.SetText(ticket.characterName);
        ControlGroupController controller = _controllers[Random.Range(0, _controllers.Length)];
        List<GameObject> objs = new List<GameObject>();
        int r = Random.Range(3, 8);
        for (int i = 0; i < r; i++)
        {
            var obj = Instantiate(_elements[Random.Range(0, _elements.Length)], controller.transform);
            obj.Init(_problems[Random.Range(0,_problems.Length)], Random.Range(0f,1f));
            objs.Add(obj.gameObject);
        }
        controller.Init(objs);
    }

    public void CompleteCall()
    {
        ClearRemote();
        _remoteParent.SetActive(false);
    }
    
    private void ClearRemote()
    {
        _controllers[0].ClearObjects();
        _controllers[1].ClearObjects();
        _controllers[2].ClearObjects();
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
    
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }
    
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
    
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
