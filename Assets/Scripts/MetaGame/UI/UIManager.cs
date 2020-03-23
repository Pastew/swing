using System.Collections.Generic;
using System.Linq;
using EasyMobile;
using MetaGame.Buttons;
using Shared;
using UnityEngine;

namespace MetaGame
{
    public class UIManager : MonoBehaviour
    {
        private List<MenuButton> _buttons;

        private void Awake()
        {
            _buttons = FindObjectsOfType<MenuButton>().ToList();
        }

        private void Start()
        {
            HideRemoveAdsButtonIfPurchased();
        }

        private void HideRemoveAdsButtonIfPurchased()
        {
            if (Advertising.IsAdRemoved())
            {
                FindObjectOfType<RemoveAdsMenuButton>().gameObject.SetActive(false);
            }
        }

        internal void ShowMenu()
        {
            _buttons.ForEach(b=> b.Show());
        }

        public void HideMenu()
        {
            _buttons.ForEach(b=> b.Hide());
        }

        // Menu canvas
        internal void ShowLevelResultsScreen(LevelScore levelScore)
        {
            ShowMenu();
            print("Stars: " + levelScore._stars);
            print("Clicks: " + levelScore._clicks);
            print("Time elapsed: " + levelScore._time);
        }

        public void SetCoinsText(int coins)
        {
            // _coinsText.GetComponent<Text>().text = coins.ToString();
        }
    }
}