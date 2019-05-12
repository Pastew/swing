using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject canvasGO;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();        
        canvasGO = transform.GetChild(0).gameObject; // TODO: I'm not sure if it's 100% safe
    }

    internal void SetCanvasVisible(bool visible)
    {
        canvasGO.SetActive(visible);
    }

    public void OnPlayNextLevelButtonClick()
    {
        gameManager.OnPlayNextLevelButtonPressed();
        SetCanvasVisible(false);
    }
}
