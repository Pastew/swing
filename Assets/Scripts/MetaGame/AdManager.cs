using System;
using EasyMobile;
using UnityEngine;

namespace MetaGame
{
    public class AdManager : MonoBehaviour
    {
        public static AdManager instance;

        private Action AdCompletedCallback;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            Advertising.InterstitialAdCompleted += InterstitialAdCompletedHandler;
        }

        public void TryShowInterstitial(Action adCompletedCallback)
        {
            AdCompletedCallback = adCompletedCallback;

#if UNITY_EDITOR
            Debug.Log("!!!!!!!!!!!! Showing Interstitial Ad !!!!!!!!!!!!!!");
            adCompletedCallback();
#else
        if (Advertising.IsInterstitialAdReady())
            Advertising.ShowInterstitialAd();
        else
            callback();

#endif
        }

        private void InterstitialAdCompletedHandler(InterstitialAdNetwork arg1, AdPlacement arg2)
        {
            AdCompletedCallback();
        }
    }
}