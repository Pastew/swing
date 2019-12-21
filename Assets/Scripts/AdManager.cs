using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    private float timer = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            timer = 0;
            ShowInterstitial();
        }
    }

    public void ShowInterstitial()
    {
        if (!GameSaveManager.instance.AdsEnabled())
            return;

        print("ShowInterstitial");
    }

    public void OnDisableAdsPurchased()
    {
        GameSaveManager.instance.OnDisableAdsPurchased();
        UIManager.instance.HideDisableAdsIfPurchased();
    }
}