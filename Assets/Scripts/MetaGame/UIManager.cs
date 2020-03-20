using EasyMobile;
using Shared;
using UnityEngine;

namespace MetaGame
{
    public class UIManager : MonoBehaviour
    {
        private GameObject _menuUI;
        private MetaFlow _metaFlow;

        private void Awake()
        {
            _metaFlow = FindObjectOfType<MetaFlow>();
            _menuUI = transform.Find("Menu").gameObject;

            HideMenu();
        }

        private void Start()
        {
            HideRemoveAdsButtonIfPurchased();
        }

        private void HideRemoveAdsButtonIfPurchased()
        {
            if (Advertising.IsAdRemoved())
            {
                _menuUI.transform.Find("RemoveAds").gameObject.SetActive(false);
            }
        }

        internal void ShowMenu()
        {
            SetMenuCanvasVisible(true);
        }

        // Menu canvas
        internal void ShowLevelResultsScreen(LevelScore levelScore)
        {
            SetMenuCanvasVisible(true);
            print("Stars: " + levelScore._stars);
            print("Clicks: " + levelScore._clicks);
            print("Time elapsed: " + levelScore._time);
        }

        private void SetMenuCanvasVisible(bool visible)
        {
            _menuUI.SetActive(visible);
        }

        public void HideMenu()
        {
            SetMenuCanvasVisible(false);
        }

        public void SetCoinsText(int coins)
        {
            // _coinsText.GetComponent<Text>().text = coins.ToString();
        }
    }
}