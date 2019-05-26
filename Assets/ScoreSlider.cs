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

    void Awake()
    {
        slider = GetComponent<Slider>();
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
}
