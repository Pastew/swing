using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    public static ScoreSlider instance;

    public float lerpSpeed = 8;

    private float currentDisplayingScore = 0;
    private int targetScore = 0;

    private int previousStarsNumber;

    private Slider slider;
    private Animator animator;

    private Image[] stars;

    // Resources
    private Sprite starFull;
    private Sprite starEmpty;

    void Awake()
    {
        instance = this;
        slider = GetComponent<Slider>();
        animator = GetComponent<Animator>();

        starEmpty = Resources.Load<Sprite>("Images/starUIEmpty") as Sprite;
        starFull = Resources.Load<Sprite>("Images/starUIFull") as Sprite;

        stars = new Image[3];
        for (int i = 0; i < 3; ++i)
            stars[i] = transform.Find("star" + (i + 1)).GetComponent<Image>();
    }

    void Update()
    {
        Score currentScore = ScoreManager.instance.GetScore();

        // Smooth slider movement
        targetScore = currentScore.finalScore;
        currentDisplayingScore = CalculateCurrentDisplayingScore();
        slider.value = currentDisplayingScore;

        // Changing stars sprites
        if (currentScore.stars != previousStarsNumber)
        {
            ShowStarsOnSliderChange(currentScore.stars);
            previousStarsNumber = currentScore.stars;
        }
    }

    public void ResetScoreSlider()
    {
        ShowStarOnSliderChange(3, false);
        ShowStarOnSliderChange(2, false);
        ShowStarOnSliderChange(1, true);

        previousStarsNumber = 0;
        int currentStarsNumber =  ScoreManager.instance.GetScore().stars;
    }


    private float CalculateCurrentDisplayingScore()
    {
        return Mathf.Lerp(currentDisplayingScore, targetScore, Time.deltaTime * lerpSpeed);
    }

    public void ShowStarsResult()
    {
        int starsToShow = ScoreManager.instance.GetScore().stars;

        animator.SetTrigger("showStars" + starsToShow);
    }

    public void StarsInSliderIdle()
    {
        animator.SetTrigger("starsInSliderIdle");
    }

    private void ShowStarsOnSliderChange(int currentStarsNumber)
    {
        if (previousStarsNumber == 0 && currentStarsNumber == 1)
            ShowStarOnSliderChange(1, true);

        else if (previousStarsNumber == 1 && currentStarsNumber == 2)
            ShowStarOnSliderChange(2, true);

        else if (previousStarsNumber == 2 && currentStarsNumber == 3)
            ShowStarOnSliderChange(3, true);


        else if (previousStarsNumber == 3 && currentStarsNumber == 2)
            ShowStarOnSliderChange(3, false);

        else if (previousStarsNumber == 2 && currentStarsNumber == 1)
            ShowStarOnSliderChange(2, false);

        else if (previousStarsNumber == 1 && currentStarsNumber == 0)
            ShowStarOnSliderChange(1, false);
    }

    private void ShowStarOnSliderChange(int changedStar, bool gained)
    {
        stars[changedStar - 1].sprite = gained ? starFull : starEmpty;
        animator.SetTrigger("shakeStarOnSlider" + changedStar);
    }
}
