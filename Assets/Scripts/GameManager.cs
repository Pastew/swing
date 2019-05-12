using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Development options
    [Tooltip("Only for development build")]
    public int startingLevel = 0;

    // External dependencies
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
        levelManager.Loadlevel(Debug.isDebugBuild ? startingLevel : 0);
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

    internal void OnRepeatButtonClick()
    {
        levelManager.ReLoadCurrentlevel();
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
