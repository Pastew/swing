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

public class MetaGameManager : MonoBehaviour
{
    public static MetaGameManager instance;

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
        LevelManager.instance.ReloadCurrentlevel();
        HookController.Instance.OnHeroDeath();
    }

    public void OnHeroReachedGoal()
    {
        AdManager.instance.TryShowInterstitial(ShowLevelResult);
    }

    private void ShowLevelResult()
    {
        UIManager.instance.ShowLevelResultsScreen(ScoreManager.instance.LevelScore);
        HookController.Instance.OnReachedGoal();
    }

    internal void OnLevelLoaded()
    {
        HookController.Instance.SetCanUseHook(false);
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
        HookController.Instance.SetCanUseHook(true);
    }

    internal void OnRepeatButtonClick()
    {
        LevelManager.instance.ReloadCurrentlevel();
    }

    // ============ UI ============
    public void OnPlayNextLevelButtonPressed()
    {
        LevelManager.instance.LoadNextLevel();
    }
}