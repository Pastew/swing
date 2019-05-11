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

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
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
    }


    internal void OnHeroDeath()
    {
        levelManager.ReLoadCurrentlevel();
        FindGameObjects();
    }

    public void OnHeroReachedGoal()
    {
        levelManager.LoadNextLevel();
        FindGameObjects();
    }

    private void FindGameObjects()
    {
        hero = FindObjectOfType<Hero>();
        hook = FindObjectOfType<Hook>();
        player.FindGameObjects();
    }
}
