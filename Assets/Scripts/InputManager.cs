using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UserClickedEvent : UnityEvent<Vector2> { }

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private GameObject _hookGO;
    private bool _canInteractWithGame = false;

    private UserClickedEvent _userClickedEvent;
    private Camera _camera;

    private void Awake()
    {
        Instance = this;
        _userClickedEvent = new UserClickedEvent();
        _hookGO = transform.GetChild(0).gameObject;
        _hookGO.SetActive(false);
        _camera = Camera.main;
    }

    void Update()
    {
        if (!_canInteractWithGame)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            OnUserClicked();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnUserReleased();
        }
    }

    internal void SubscribeToUserClicked(UnityAction<Vector2> subscriber)
    {
        _userClickedEvent.AddListener(subscriber);
    }

    private void OnUserReleased()
    {
        _hookGO.SetActive(false);
    }

    private void OnUserClicked()
    {
        _hookGO.transform.position = GetNewHookPosition();
        _hookGO.SetActive(true);

        _userClickedEvent.Invoke(_hookGO.transform.position);
    }

    private Vector3 GetNewHookPosition()
    {
        Vector3 newHookPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(newHookPos.x, newHookPos.y, 0);
    }

    public void OnHeroDeath()
    {
        if(_hookGO)
            _hookGO.gameObject.SetActive(false);
    }

    internal void SetCanUseHook(bool newValue)
    {
        _canInteractWithGame = newValue;
    }

    internal void OnReachedGoal()
    {
        if (_hookGO)
            _hookGO.gameObject.SetActive(false);

        SetCanUseHook(false);
    }
}