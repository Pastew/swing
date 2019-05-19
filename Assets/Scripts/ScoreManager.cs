﻿using System;
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

    private UIManager uiManager;
    private Clock clock;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        clock = FindObjectOfType<Clock>();
        clock.AddOnTickListener(OnTimeUnitElapsed);
    }

    private void Start()
    {
        print("MaxPossibleScore = " + GetMaxPossibleScore());
    }


    public void ResetScore()
    {
        score = new Score();
        clock.StopClock();
        timeNeededForNextTimeUnitElapsed = timeUnit;
        uiManager.UpdateScoreUI(CalculateFinalScore(score));
    }

    public Score GetScore()
    {
        score.finalScore = CalculateFinalScore(score);
        score.stars = CalculateStars();
        clock.StopClock();
        return score;
    }

    // Game events
    public void BonusPointCollected()
    {
        score.bonusPoints++;
        uiManager.UpdateScoreUI(CalculateFinalScore(score), bonus);
    }

    internal void StartTimer()
    {
        clock.StartClock();
    }

    public void OnUserClicked()
    {
        score.clicks++;
        uiManager.UpdateScoreUI(CalculateFinalScore(score), -clickCost);
    }

    public void OnTimeUnitElapsed()
    {
        score.timeElapsed++;
        uiManager.UpdateScoreUI(CalculateFinalScore(score), -1);
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

        int unit = GetMaxPossibleScore() / 4;

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

}
