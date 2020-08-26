using System;
using Shared;
using UnityEngine;

namespace MetaGame
{
    public class MetaFlow : MonoBehaviour
    {
        private UIManager _uiManager;
        private LevelManager _levelManager;

        private int _lastWorldId;

        private void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();
            _levelManager = FindObjectOfType<LevelManager>();
            MetaEvents.NextLevelButtonPressedEvent += () =>
            {
                _uiManager.HideCurrentPanel();
                _levelManager.LoadNextLevel();
            };

            MetaEvents.ReplayButtonPressedEvent += () =>
            {
                _uiManager.HideCurrentPanel();
                _levelManager.LoadCurrentLevel();
            };

            MetaEvents.MainMenuButtonPressedEvent += () => { _uiManager.ShowMainMenuPanel(); };

            MetaEvents.WorldsSelectButtonPressedEvent += () => { _uiManager.ShowWorldsPanel(); };

            MetaEvents.WorldButtonPressedEvent += worldId =>
            {
                _uiManager.ShowWorldPanel(worldId);
                _lastWorldId = worldId;
            };

            MetaEvents.LastWorldButtonPressedEvent += () => { _uiManager.ShowWorldPanel(_lastWorldId); };
        }

        private void Start()
        {
            _uiManager.HideRemoveAdsButtonIfAlreadyPurchased();
            _uiManager.ShowMainMenuPanel();
        }

        public void OnLevelFinished(LevelScore levelScore)
        {
            _uiManager.ShowLevelResultsScreen(levelScore);
        }
    }
}