using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentLevelIndex;
    private GameObject currentLevel;
    private GameManager gameManager;

    public GameObject heroPrefab;
    private GameObject hero;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Loadlevel(int levelIndex)
    {
        Destroy(currentLevel);

        currentLevelIndex = levelIndex;

        string path = "Levels/Level_" + currentLevelIndex;
        try
        {
            currentLevel = Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
        }
        catch (ArgumentException argEx)
        {
            Debug.LogError("Level you're trying to load doesn't exist: " + path + ".  will load level 0");
            Loadlevel(0);
            return;
        }

        ReloadHero();
        gameManager.OnLevelLoaded();
    }

    private void ReloadHero()
    {
        Destroy(hero);
        hero = Instantiate(heroPrefab, GetStartPosition(), Quaternion.identity);
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        Loadlevel(currentLevelIndex);
    }

    internal void ReLoadCurrentlevel()
    {
        Loadlevel(currentLevelIndex);
    }

    internal Vector3 GetStartPosition()
    {
        return currentLevel.GetComponentInChildren<StartPosition>().transform.position;
    }
}
