using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Score score;
    readonly int startingScore = 40;
    readonly int bonus = 15;
    readonly int clickCost = 5;

    readonly float timeUnit = 1;
    float timeNeededForNextTimeUnitElapsed;
    private bool timerStopped = true;

    private void Start()
    {
        print("MaxPossibleScore = " + GetMaxPossibleScore());
    }

    private void Update()
    {
        timeNeededForNextTimeUnitElapsed -= Time.deltaTime;
        if (!timerStopped && timeNeededForNextTimeUnitElapsed <= 0)
        {
            OnTimeUnityElapsed();
            timeNeededForNextTimeUnitElapsed = timeUnit;
        }
    }

    public void ResetScore()
    {
        score = new Score();
        timeNeededForNextTimeUnitElapsed = timeUnit;
        timerStopped = false;
    }

    public Score GetScore()
    {
        score.finalScore = CalculateFinalScore(score);
        timerStopped = true;
        return score;
    }

    private int CalculateFinalScore(Score score)
    {
        return startingScore - score.timeElapsed + score.bonusPoints * bonus - score.clicks * clickCost;
    }

    public void BonusPointCollected()
    {
        score.bonusPoints++;
    }

    public void OnUserClicked()
    {
        score.clicks++;
    }

    public void OnTimeUnityElapsed()
    {
        score.timeElapsed++;
    }

    public int GetMaxPossibleScore()
    {
        return startingScore + bonus * 3 - clickCost;
    }
}
