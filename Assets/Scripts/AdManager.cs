﻿using System;
using EasyMobile;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    private float timer = 0;

    private Action callback;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        Advertising.InterstitialAdCompleted += InterstitialAdCompletedHandler;
    }
    
    public void TryShowInterstitial(Action callback)
    {
        this.callback = callback;
        ConsentStatus moduleConsent = Advertising.DataPrivacyConsent;
        Advertising.GrantDataPrivacyConsent(AdNetwork.UnityAds);

        if (Advertising.IsInterstitialAdReady())
            Advertising.ShowInterstitialAd();
        else
            callback();
    }

    private void InterstitialAdCompletedHandler(InterstitialAdNetwork arg1, AdPlacement arg2)
    {
        callback();
    }
}