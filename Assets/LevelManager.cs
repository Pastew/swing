using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentLevelIndex;
    private GameObject currentLevel;

    public void Loadlevel(int levelIndex)
    {
        Destroy(currentLevel);

        currentLevelIndex = levelIndex;

        string path = "Levels/Level_" + currentLevelIndex;
        try
        {
            currentLevel = Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
        }catch(ArgumentException argEx)
        {
            Debug.LogError("Level you're trying to load doesn't exist: " + path + ".  will load level 0");
            Loadlevel(0);
        }
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

    internal void DevSetCurrentLevel(GameObject gameObject)
    {
        currentLevel = gameObject;
    }

    internal void DevSetCurrentLevelIndex(int developmentLevelIndex)
    {
        currentLevelIndex = developmentLevelIndex;
    }
}
