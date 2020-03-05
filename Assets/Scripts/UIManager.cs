using System.Collections;
using EasyMobile;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // Parameters
    [Tooltip("In seconds")] private int countdownTicks = 4;
    private float oneCountdownLength = 0.5f;

    // Childs
    private GameObject menuUI;
    private GameObject counterUI;
    private GameObject coinsPanel;
    private GameObject coinsText;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        menuUI = transform.Find("Menu").gameObject;
        counterUI = transform.Find("Counter").gameObject;
        coinsPanel = menuUI.transform.Find("CoinsPanel").gameObject;
        coinsText = coinsPanel.transform.Find("CoinsText").gameObject;

        SetupButtonListeners();
        HideAllUI();
    }

    private void Start()
    {
        HideRemoveAdsButtonIfPurchased();
        GameManager.instance.SubscribeToLevelLoadedEvent(OnLevelLoaded);
    }

    public void HideRemoveAdsButtonIfPurchased()
    {
        if (Advertising.IsAdRemoved())
        {
            menuUI.transform.Find("RemoveAds").gameObject.SetActive(false);
        }
    }

    private void SetupButtonListeners()
    {
        menuUI.transform.Find("Play").GetComponent<Button>().onClick.AddListener(OnPlayNextLevelButtonPressed);
        menuUI.transform.Find("Repeat").GetComponent<Button>().onClick.AddListener(OnRepeatButtonPressed);
    }

    internal void ShowTutorial()
    {
    }

    internal void OnLevelLoaded()
    {
        StartCountdown();
    }

    internal void ShowMenu()
    {
        HideAllUI();
        SetMenuCanvasVisible(true);
    }

    // Menu canvas
    internal void ShowLevelResultsScreen(LevelScore levelScore)
    {
        SetMenuCanvasVisible(true);
        print("Clicks: " + levelScore.clicks);
        print("Time elapsed: " + levelScore.time);
    }

    public void SetMenuCanvasVisible(bool visible)
    {
        menuUI.SetActive(visible);
    }

    private void HideAllUI()
    {
        SetMenuCanvasVisible(false);
    }

    public void OnPlayNextLevelButtonPressed()
    {
        GameManager.instance.OnPlayNextLevelButtonPressed();
        HideAllUI();
    }


    public void OnRepeatButtonPressed()
    {
        GameManager.instance.OnRepeatButtonClick();
        HideAllUI();
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
}