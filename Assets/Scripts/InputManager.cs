using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameObject hookGO;

    private bool canInteractWithGame = false;

    private void Awake()
    {
        hookGO = transform.GetChild(0).gameObject;
        hookGO.SetActive(false);
    }

    void Update()
    {
        if (!canInteractWithGame)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            hookGO.transform.position = GetNewHookPosition();
            hookGO.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            hookGO.SetActive(false);
        }
    }

    private Vector3 GetNewHookPosition()
    {
        Vector3 newHookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(newHookPos.x, newHookPos.y, 0);
    }

    public void OnHeroDeath()
    {
        if(hookGO)
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
