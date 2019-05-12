using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Hero hero;
    private Hook hook;

    private HookController player;
    private LevelManager levelManager;
    private UIManager uiManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<HookController>();
        uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        // Dev only if TODO: remove it 
        if (FindObjectOfType<Hero>())
        {
            int developmentLevelIndex = Int32.Parse(FindObjectOfType<Hero>().gameObject.transform.parent.name.Split('_')[1]);
            levelManager.DevSetCurrentLevel(FindObjectOfType<Hero>().gameObject.transform.parent.gameObject);
            levelManager.DevSetCurrentLevelIndex(developmentLevelIndex);
            OnLevelLoaded();
        }
        else
        {
            levelManager.Loadlevel(0);
        }
    }

    // ============ Game Events ============

    internal void OnHeroDeath()
    {
        levelManager.ReLoadCurrentlevel();

        // Hide hook if it's visible.
        if (hook)
            hook.gameObject.SetActive(false);
    }

    public void OnHeroReachedGoal()
    {
        ShowCanvas();
        player.SetCanInteractWithGame(false);
    }

    internal void OnLevelLoaded()
    {
        FindGameObjects();
        player.SetCanInteractWithGame(true);
    }

    // ============ UI ============
    private void ShowCanvas()
    {
        uiManager.SetCanvasVisible(true);
    }

    public void OnPlayNextLevelButtonPressed()
    {
        levelManager.LoadNextLevel();
    }

    // ============ Helpers ============
    private void FindGameObjects()
    {
        hero = FindObjectOfType<Hero>();
        hook = FindObjectOfType<Hook>();
        player.FindGameObjects();
    }
}
