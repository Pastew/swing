using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using EasyMobile;
using MetaGame.Buttons;
using Shared;
using UnityEngine;

namespace MetaGame.UI
{
    public class UIManager : MonoBehaviour
    {
        private List<MenuButton> _buttons;
        private LevelScorePanel _levelScorePanel;
        private UIPanel _currentPanel;

        private void Awake()
        {
            _buttons = FindObjectsOfType<MenuButton>().ToList();
            _levelScorePanel = FindObjectOfType<LevelScorePanel>();
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

        private void ShowButtons()
        {
            _buttons.ForEach(b=> b.Show());
        }

        public void HideButtons()
        {
            _buttons.ForEach(b=> b.Hide());
        }

        // Menu canvas
        internal void ShowLevelResultsScreen(LevelScore levelScore)
        {
            _currentPanel = _levelScorePanel;
            Sequence seq = DOTween.Sequence();
            seq.Append(_levelScorePanel.Show(levelScore));
            seq.AppendCallback(ShowButtons);
            seq.Play();
            
            print("Stars: " + levelScore._stars);
            print("Clicks: " + levelScore._clicks);
            print("Time elapsed: " + levelScore._time);
        }

        public void SetCoinsText(int coins)
        {
            // _coinsText.GetComponent<Text>().text = coins.ToString();
        }

        public void HideCurrentPanel()
        {
            if (_currentPanel != null)
            {
                _currentPanel.Hide();
                _currentPanel = null;
            }
        }
    }
}