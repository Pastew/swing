using System;
using Shared;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject heroPrefab;
    private GameObject hero;
    private GameObject currentLevel;

    public static LevelLoader instance;

    private void Awake()
    {
        instance = this;
        SharedEvents.LoadLevelAction += Loadlevel;
    }
    
    private void Loadlevel(int levelIndex)
    {
        Destroy(currentLevel);

        string path = "Levels/Level_" + levelIndex;
        try
        {
            currentLevel = Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
        }
        catch (ArgumentException argEx)
        {
            int lvlToLoad = 1;
            Debug.LogError($"Level you're trying to load doesn't exist: {path}.  will load level {lvlToLoad}");
            return;
        }

        ReloadHero();
        MetaGameManager.instance.OnLevelLoaded();
    }
    
    private void ReloadHero()
    {
        Destroy(hero);
        hero = Instantiate(heroPrefab, GetStartPosition(), Quaternion.identity);
    }
    
    private Vector3 GetStartPosition()
    {
        return currentLevel.GetComponentInChildren<StartPosition>().transform.position;
    }
}
