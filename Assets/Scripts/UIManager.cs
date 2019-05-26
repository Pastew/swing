using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // Parameters
    [Tooltip("In seconds")]
    private int countdownTicks = 4;
    private float oneCountdownLength = 0.5f;

    // Childs
    private GameObject menuUI;
    private GameObject counterUI;
    private GameObject starsUI;
    private GameObject hudUI;
    private GameObject coinsPanel;
    private GameObject coinsText;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        menuUI = transform.Find("Menu").gameObject;
        counterUI = transform.Find("Counter").gameObject;
        starsUI = transform.Find("Stars").gameObject;
        hudUI = transform.Find("HUD").gameObject;
        coinsPanel = menuUI.transform.Find("CoinsPanel").gameObject;
        coinsText = coinsPanel.transform.Find("CoinsText").gameObject;

        SetupButtonListeners();
        HideAllUI();
    }

    private void Start()
    {
        HideDisableAdsIfPurchased();
    }

    public void HideDisableAdsIfPurchased()
    {
        print("HideDisableAdsIfPurchased");
        if (!GameSaveManager.instance.AdsEnabled())
        {
            menuUI.transform.Find("NoAds").gameObject.GetComponent<Image>().enabled = false;
        }
    }

    private void SetupButtonListeners()
    {
        menuUI.transform.Find("Play").GetComponent<Button>().onClick.AddListener(OnPlayNextLevelButtonPressed);
        menuUI.transform.Find("Repeat").GetComponent<Button>().onClick.AddListener(OnRepeatButtonPressed);
    }


    internal void ShowMenu()
    {
        HideAllUI();
        hudUI.SetActive(false);
        SetMenuCanvasVisible(true);
    }

    // Menu canvas
    internal void ShowLevelResultsScreen(Score score)
    {
        SetMenuCanvasVisible(true);
        starsUI.SetActive(true);
        starsUI.GetComponent<StarsUI>().ShowStars(score.stars);
        print("Clicks: " + score.clicks);
        print("Time elapsed: " + score.timeElapsed);
        print("Final score: " + score.finalScore);
    }

    public void SetMenuCanvasVisible(bool visible)
    {
        menuUI.SetActive(visible);
    }

    private void HideAllUI()
    {
        SetMenuCanvasVisible(false);
        starsUI.SetActive(false);
    }

    public void OnPlayNextLevelButtonPressed()
    {
        GameManager.instance.OnPlayNextLevelButtonPressed();
        HideAllUI();
        hudUI.SetActive(true);
    }


    public void OnRepeatButtonPressed()
    {
        GameManager.instance.OnRepeatButtonClick();
        HideAllUI();
        hudUI.SetActive(true);
    }

    // Coins
    public void SetCoinsText(int coins)
    {
        coinsText.GetComponent<Text>().text = coins.ToString();
    }

    // Countdown
    private void SetCounterCanvasText(string text)
    {
        counterUI.GetComponentInChildren<Text>().text = text;
    }

    internal void StartCountdown()
    {
        StartCoroutine(Countdown(countdownTicks));
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            SetCounterCanvasText(count.ToString());
            yield return new WaitForSeconds(oneCountdownLength);
            count--;
        }

        SetCounterCanvasText("");
        GameManager.instance.OnCountdownFinished();
    }

    // HUD
    public void UpdateScoreText(int newScore, int change = 0)
    {
        if (newScore >= 0)
            hudUI.GetComponentInChildren<Text>().text = newScore.ToString();
        else
            hudUI.GetComponentInChildren<Text>().text = "<0";
    }
}
