using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // External dependencies
    private GameManager gameManager;

    // Parameters
    [Tooltip("In seconds")]
    private float oneCountdownLength = 0.3f;

    // Childs
    private GameObject menuUI;
    private GameObject counterUI;
    private GameObject starsUI;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        menuUI = transform.Find("Menu").gameObject;
        counterUI = transform.Find("Counter").gameObject;
        starsUI = transform.Find("Stars").gameObject;
    }

    private void Start()
    {
        menuUI.transform.Find("Play").GetComponent<Button>().onClick.AddListener(OnPlayNextLevelButtonClick);
        menuUI.transform.Find("Repeat").GetComponent<Button>().onClick.AddListener(OnRepeatButtonClick);
    }

    // Menu canvas
    internal void ShowLevelResultsScreen(int collectedStars)
    {
        SetMenuCanvasVisible(true);
        starsUI.SetActive(true);
        starsUI.GetComponent<StarsUI>().ShowStars(collectedStars);
    }

    public void SetMenuCanvasVisible(bool visible)
    {
        menuUI.SetActive(visible);
    }

    public void OnPlayNextLevelButtonClick()
    {
        gameManager.OnPlayNextLevelButtonPressed();
        SetMenuCanvasVisible(false);
    }

    public void OnRepeatButtonClick()
    {
        gameManager.OnRepeatButtonClick();
        SetMenuCanvasVisible(false);
    }

    // Counter
    private void SetCounterCanvasText(string text)
    {
        counterUI.GetComponentInChildren<Text>().text = text;
    }

    private void SetCoutnerCanvasActive(bool active)
    {
        counterUI.SetActive(active);
    }

    internal void StartCountdown()
    {
        StartCoroutine(Countdown(5));
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        SetCoutnerCanvasActive(true);

        while (count > 0)
        {
            SetCounterCanvasText(count.ToString());
            yield return new WaitForSeconds(oneCountdownLength);
            count--;
        }

        SetCoutnerCanvasActive(false);
        gameManager.OnCountdownFinished();
    }
}
