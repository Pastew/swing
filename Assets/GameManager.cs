using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Hero hero;
    private Hook hook;

    private Player player;
    private LevelManager levelManager;
    private UIManager uiManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
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
        }
        else
        {
            levelManager.Loadlevel(0);
        }
        FindGameObjects();
        player.SetCanInteractWithGame(true);
    }


    internal void OnHeroDeath()
    {
        levelManager.ReLoadCurrentlevel();
        FindGameObjects();
    }

    public void OnHeroReachedGoal()
    {
        ShowCanvas();
        player.SetCanInteractWithGame(false);
    }

    private void ShowCanvas()
    {
        uiManager.SetCanvasVisible(true);
    }

    private void FindGameObjects()
    {
        hero = FindObjectOfType<Hero>();
        hook = FindObjectOfType<Hook>();
        player.FindGameObjects();
    }

    public void OnPlayNextLevelButtonPressed()
    {
        levelManager.LoadNextLevel();
        FindGameObjects();
        player.SetCanInteractWithGame(true);
    }
}
