using EasyMobile;
using Shared;
using UnityEngine;

namespace MetaGame
{
    public class UIManager : MonoBehaviour
    {
        private UIPanel _currentPanel;
        private MainMenuPanel _mainMenuPanel;
        private LevelsPanel _levelsPanel;
        private LevelResultPanel _levelResultPanel;

        private void Awake()
        {
            _mainMenuPanel = FindObjectOfType<MainMenuPanel>();
            _levelsPanel = FindObjectOfType<LevelsPanel>();
            _levelResultPanel = FindObjectOfType<LevelResultPanel>();

            _currentPanel = _mainMenuPanel;
            MetaEvents.LevelResultShownEvent += OnLevelResultScreenShown;
        }

        private void Start()
        {
            HideRemoveAdsButtonIfPurchased();
            _levelsPanel.Hide(true);
            _levelResultPanel.Hide(true);
        }

        private void HideRemoveAdsButtonIfPurchased()
        {
            if (Advertising.IsAdRemoved())
            {
                FindObjectOfType<RemoveAdsMovingMenuButton>().gameObject.SetActive(false);
            }
        }

        // Menu canvas
        internal void ShowLevelResultsScreen(LevelScore levelScore)
        {
            _levelResultPanel.Setup(levelScore);
            _currentPanel = _levelResultPanel;
            _levelResultPanel.Show();
        }
        
        private void OnLevelResultScreenShown()
        {
        }
        
        public void ShowLevelsPanel()
        {
            ShowPanel(_levelsPanel);
        }
        
        public void ShowMainMenuPanel()
        {
            ShowPanel(_mainMenuPanel);
        }

        private void ShowPanel(UIPanel panel)
        {
            HideCurrentPanel();
            panel.Show();
            _currentPanel = panel;
        }


        public void SetCoinsText(int coins)
        {
            // _coinsText.GetComponent<Text>().text = coins.ToString();
        }

        public void HideCurrentPanel()
        {
            _currentPanel.Hide();
            _currentPanel = null;
        }
    }
}