using Shared;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentLevelIndex;
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        SharedEvents.LoadLevelAction(currentLevelIndex);
    }

    public void ReloadCurrentlevel()
    {
        SharedEvents.LoadLevelAction(currentLevelIndex);
    }

    internal int GetCurrentLevelIndex()
    {
        return currentLevelIndex;
    }
}
