using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BonusPointCollectedEvent : UnityEvent<BonusPoint> { }

[Serializable]
public class LevelLoadedEvent : UnityEvent { }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Development options
    [Tooltip("Only for development build")]
    public int startingLevel = 0;

    private BonusPointCollectedEvent bonusPointCollectedEvent;
    private LevelLoadedEvent levelLoadedEvent;

    private void Awake()
    {
        instance = this;
        bonusPointCollectedEvent = new BonusPointCollectedEvent();
        levelLoadedEvent = new LevelLoadedEvent();
    }

    void Start()
    {
        //LevelManager.instance.Loadlevel(Debug.isDebugBuild ? startingLevel : 0);
        UIManager.instance.ShowMenu();
    }

    // ============ Game Events ============
    internal void OnHeroDeath()
    {
        LevelManager.instance.ReLoadCurrentlevel();
        InputManager.instance.OnHeroDeath();
    }

    public void OnHeroReachedGoal()
    {
        UIManager.instance.ShowLevelResultsScreen(ScoreManager.instance.GetScore());
        Clock.instance.StopClock();
        InputManager.instance.OnReachedGoal();
    }

    internal void OnLevelLoaded()
    {
        if (LevelManager.instance.GetCurrentLevelIndex() <= 2)
            UIManager.instance.ShowTutorial();

        InputManager.instance.SetCanUseHook(false);
        ScoreManager.instance.ResetScore();
        levelLoadedEvent.Invoke();
    }

    internal void OnBonusPointCollected(BonusPoint bonusPoint)
    {
        bonusPointCollectedEvent.Invoke(bonusPoint);
        Destroy(bonusPoint.gameObject);
    }

    public void SubscribeToBonusPointCollected(UnityAction<BonusPoint> subscriber)
    {
        bonusPointCollectedEvent.AddListener(subscriber);
    }

    public void SubscribeToLevelLoadedEvent(UnityAction subscriber)
    {
        levelLoadedEvent.AddListener(subscriber);
    }

    public void OnCountdownFinished()
    {
        FindObjectOfType<Hero>().OnCountdownFinished();
        ScoreManager.instance.StartTimer();
        InputManager.instance.SetCanUseHook(true);
    }

    internal void OnRepeatButtonClick()
    {
        LevelManager.instance.ReLoadCurrentlevel();
    }

    // ============ UI ============
    public void OnPlayNextLevelButtonPressed()
    {
        LevelManager.instance.LoadNextLevel();
    }
}
