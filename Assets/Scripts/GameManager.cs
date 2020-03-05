using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BonusPointCollectedEvent : UnityEvent<Star>
{
}

[Serializable]
public class LevelLoadedEvent : UnityEvent
{
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Development options
    [Tooltip("Only for development build")]

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
        AdManager.instance.TryShowInterstitial(ShowLevelResult);
    }

    private void ShowLevelResult()
    {
        UIManager.instance.ShowLevelResultsScreen(ScoreManager.instance.LevelScore);
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

    internal void OnBonusPointCollected(Star star)
    {
        bonusPointCollectedEvent.Invoke(star);
        Destroy(star.gameObject);
    }

    public void SubscribeToBonusPointCollected(UnityAction<Star> subscriber)
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