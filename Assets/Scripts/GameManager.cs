using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InputManager inputManager;
    private LevelManager levelManager;
    private UIManager uiManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        inputManager = FindObjectOfType<InputManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        levelManager.Loadlevel(0);
    }

    // ============ Game Events ============
    internal void OnHeroDeath()
    {
        levelManager.ReLoadCurrentlevel();
        inputManager.OnHeroDeath();
    }

    public void OnHeroReachedGoal()
    {
        ShowCanvas();
        inputManager.OnReachedGoal();
    }

    internal void OnLevelLoaded()
    {
        uiManager.StartCountdown();
    }

    public void OnCountdownFinished()
    {
        inputManager.SetCanUseHook(true);
        FindObjectOfType<Hero>().OnCountdownFinished();
    }

    // ============ UI ============
    private void ShowCanvas()
    {
        uiManager.SetMenuCanvasVisible(true);
    }

    public void OnPlayNextLevelButtonPressed()
    {
        levelManager.LoadNextLevel();
    }
}
