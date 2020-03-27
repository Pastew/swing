using System.Collections.Generic;
using System.Linq;
using EasyMobile;
using MetaGame.Buttons;
using Shared;
using UnityEngine;

namespace MetaGame.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _levelScorePanelPrefab;
        
        private List<MenuButton> _buttons;
        private UIPanel _currentPanel;

        private void Awake()
        {
            _buttons = FindObjectsOfType<MenuButton>().ToList();

            MetaEvents.LevelResultShown += OnLevelResultScreenShown;
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
            _buttons.ForEach(b => b.Show());
        }

        public void HideButtons()
        {
            _buttons.ForEach(b => b.Hide());
        }

        // Menu canvas
        internal void ShowLevelResultsScreen(LevelScore levelScore)
        {
            LevelScorePanel levelScorePanel = Instantiate(_levelScorePanelPrefab, transform).GetComponent<LevelScorePanel>();
            _currentPanel = levelScorePanel.GetComponent<UIPanel>();
            levelScorePanel.Show(levelScore);
        }

        private void OnLevelResultScreenShown()
        {
            ShowButtons();
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