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
    private float oneCountdownLength = 0.5f;

    // Childs
    private GameObject menuCanvas;
    private GameObject counterCanvas;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        menuCanvas = transform.Find("MenuCanvas").gameObject;
        counterCanvas = transform.Find("CounterCanvas").gameObject;
    }

    // Menu canvas
    public void SetMenuCanvasVisible(bool visible)
    {
        menuCanvas.SetActive(visible);
    }

    public void OnPlayNextLevelButtonClick()
    {
        gameManager.OnPlayNextLevelButtonPressed();
        SetMenuCanvasVisible(false);
    }

    // Counter
    private void SetCounterCanvasText(string text)
    {
        counterCanvas.GetComponentInChildren<Text>().text = text;
    }

    private void SetCoutnerCanvasActive(bool active)
    {
        counterCanvas.SetActive(active);
    }

    internal void StartCountdown()
    {
        StartCoroutine(Countdown(3));
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
