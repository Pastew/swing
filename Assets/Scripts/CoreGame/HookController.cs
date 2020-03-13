using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UserClickedEvent : UnityEvent<Vector2>
{
}

public class HookController : MonoBehaviour
{
    public static HookController Instance;

    private GameObject hookGO;
    private bool canInteractWithGame = false;

    private UserClickedEvent userClickedEvent;
    private Camera _camera;

    private void Awake()
    {
        Instance = this;
        userClickedEvent = new UserClickedEvent();
        hookGO = transform.GetChild(0).gameObject;
        hookGO.SetActive(false);
        _camera = Camera.main;
    }

    void Update()
    {
        if (!canInteractWithGame)
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
        userClickedEvent.AddListener(subscriber);
    }

    private void OnUserReleased()
    {
        hookGO.SetActive(false);
    }

    private void OnUserClicked()
    {
        hookGO.transform.position = GetNewHookPosition();
        hookGO.SetActive(true);

        userClickedEvent.Invoke(hookGO.transform.position);
    }

    private Vector3 GetNewHookPosition()
    {
        Vector3 newHookPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(newHookPos.x, newHookPos.y, 0);
    }

    public void OnHeroDeath()
    {
        if (hookGO)
            hookGO.gameObject.SetActive(false);
    }

    internal void SetCanUseHook(bool newValue)
    {
        canInteractWithGame = newValue;
    }

    internal void OnReachedGoal()
    {
        if (hookGO)
            hookGO.gameObject.SetActive(false);

        SetCanUseHook(false);
    }
}