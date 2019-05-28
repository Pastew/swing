using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Score score;
    readonly int startingScore = 30;
    readonly int bonus = 15;
    readonly int clickCost = 5;

    readonly int bonusPointsNumber = 5;

    readonly float timeUnit = 1;
    float timeNeededForNextTimeUnitElapsed;

    internal static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Debug.Log("MaxPossibleScore = " + GetMaxPossibleScore());
        Clock.instance.SubscribeToClockTick(OnTimeUnitElapsed);
        GameManager.instance.SubscribeToBonusPointCollected(OnBonusPointCollected);
        InputManager.instance.SubscribeToUserClicked(OnUserClicked);
    }

    public void ResetScore()
    {
        score = new Score();
        Clock.instance.StopClock();
        timeNeededForNextTimeUnitElapsed = timeUnit;
    }

    public Score GetScore()
    {
        score.finalScore = CalculateFinalScore(score);
        score.stars = CalculateStars();
        return score;
    }

    // Game events
    public void OnBonusPointCollected(BonusPoint bonusPoint)
    {
        score.bonusPoints++;
        UIManager.instance.UpdateScoreText(CalculateFinalScore(score), bonus);
    }

    internal void StartTimer()
    {
        Clock.instance.StartClock();
    }

    public void OnUserClicked(Vector2 pos)
    {
        score.clicks++;
    }

    public void OnTimeUnitElapsed()
    {
        score.timeElapsed++;
        UIManager.instance.UpdateScoreText(CalculateFinalScore(score), -1);
    }


    // Calculations
    private int CalculateFinalScore(Score score)
    {
        return startingScore - score.timeElapsed + score.bonusPoints * bonus - score.clicks * clickCost;
    }

    public int GetMaxPossibleScore()
    {
        return startingScore + bonus * bonusPointsNumber - clickCost;
    }

    private int CalculateStars()
    {
        int s = CalculateFinalScore(score);
        int unit = OneStarTreshold();

        if (s < unit)
            return 0;

        if (unit <= s && s < 2 * unit)
            return 1;

        if (unit * 2 <= s && s < 3 * unit)
            return 2;

        if (unit * 3 <= s)
            return 3;

        Debug.LogError("This should never happen!");
        return 0;
    }

    public int OneStarTreshold()
    {
        return GetMaxPossibleScore() / 4;
    }
}
