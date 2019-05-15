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

    readonly int bonusPointsNumber = 5;

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
        score.stars = CalculateStars();
        timerStopped = true;
        return score;
    }

    // Game events
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
