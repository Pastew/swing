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
    private ScoreManager scoreManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        inputManager = FindObjectOfType<InputManager>();
        uiManager = FindObjectOfType<UIManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Start()
    {
        //levelManager.Loadlevel(Debug.isDebugBuild ? startingLevel : 0);
        uiManager.ShowStartingMenu();
    }

    // ============ Game Events ============
    internal void OnHeroDeath()
    {
        levelManager.ReLoadCurrentlevel();
        inputManager.OnHeroDeath();
    }

    public void OnHeroReachedGoal()
    {
        uiManager.ShowLevelResultsScreen(scoreManager.GetScore());
        inputManager.OnReachedGoal();
    }

    internal void OnLevelLoaded()
    {
        inputManager.SetCanUseHook(true);
        uiManager.StartCountdown();
    }

    public void OnCountdownFinished()
    {
        FindObjectOfType<Hero>().OnCountdownFinished();
        scoreManager.ResetScore();
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
