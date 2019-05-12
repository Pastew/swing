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
    private StarsManager starsManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        inputManager = FindObjectOfType<InputManager>();
        uiManager = FindObjectOfType<UIManager>();
        starsManager = FindObjectOfType<StarsManager>();
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
        uiManager.ShowLevelResultsScreen(starsManager.CollectedStars);
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
        starsManager.ResetStarsCounter();
    }

    internal void OnRepeatButtonClick()
    {
        levelManager.ReLoadCurrentlevel();
    }

    // ============ UI ============
    public void OnPlayNextLevelButtonPressed()
    {
        levelManager.LoadNextLevel();
    }
}
