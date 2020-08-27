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
        private WorldsPanel _worldsPanel;

        private void Awake()
        {
            _mainMenuPanel = FindObjectOfType<MainMenuPanel>();
            _levelsPanel = FindObjectOfType<LevelsPanel>();
            _levelResultPanel = FindObjectOfType<LevelResultPanel>();
            _worldsPanel = FindObjectOfType<WorldsPanel>();

            MetaEvents.LevelResultShownEvent += OnLevelResultScreenShown;
        }

        public void HideRemoveAdsButtonIfAlreadyPurchased()
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

        public void ShowLevelsPanel(int worldIndex)
        {
            _levelsPanel.Setup(worldIndex);
            ShowPanel(_levelsPanel);
        }

        public void ShowMainMenuPanel()
        {
            ShowPanel(_mainMenuPanel);
        }

        public void ShowWorldsPanel()
        {
            ShowPanel(_worldsPanel);
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
            if (_currentPanel != null)
            {
                _currentPanel.Hide();
                _currentPanel = null;
            }
        }
    }
}