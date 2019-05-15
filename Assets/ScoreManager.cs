using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Score score;
    readonly int startingScore = 25;
    readonly int bonus = 10;
    readonly int clickCost = 5;

    public void ResetScore()
    {
        score = new Score();
    }

    public Score GetScore()
    {
        score.finalScore = CalculateFinalScore(score);
        return score;
    }

    private int CalculateFinalScore(Score score)
    {
        return startingScore - score.timeElapsed + score.bonusPoints * bonus - score.bonusPoints * clickCost;
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
        score.timeElapsed--;
    }

    public int GetMaxPossibleScore()
    {
        return startingScore + bonus * 3 - clickCost;
    }

}
