using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameObject hookGO;

    private bool canInteractWithGame = false;
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        hookGO = transform.GetChild(0).gameObject;
        hookGO.SetActive(false);
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

    private void OnUserReleased()
    {
        hookGO.SetActive(false);
    }

    private void OnUserClicked()
    {
        hookGO.transform.position = GetNewHookPosition();
        hookGO.SetActive(true);

        scoreManager.OnUserClicked();
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
