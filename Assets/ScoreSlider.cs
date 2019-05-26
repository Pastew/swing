using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    public float lerpSpeed = 3;

    private float currentDisplayingScore = 0;
    private int targetScore = 0;

    private Slider slider;
    public static ScoreSlider instance;

    private Animator animator;

    void Awake()
    {
        instance = this;
        slider = GetComponent<Slider>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        targetScore = ScoreManager.instance.GetScore().finalScore;
        currentDisplayingScore = CalculateCurrentDisplayingScore();
        slider.value = currentDisplayingScore;
    }

    private float CalculateCurrentDisplayingScore()
    {
        return Mathf.Lerp(currentDisplayingScore, targetScore, Time.deltaTime * lerpSpeed);
    }

    public void ShowStars()
    {
        int starsToShow = ScoreManager.instance.GetScore().stars;

        animator.SetTrigger("showStars" + starsToShow);
    }

    public void StarsInSliderIdle()
    {
        animator.SetTrigger("starsInSliderIdle");
    }
}
