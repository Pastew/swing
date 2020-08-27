using System;
using Shared;
using UnityEngine;

namespace MetaGame
{
    public class MetaFlow : MonoBehaviour
    {
        private UIManager _uiManager;
        private LevelManager _levelManager;

        private int _lastWorldIndex;

        private void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();
            _levelManager = FindObjectOfType<LevelManager>();
            MetaEvents.LoadLevelEvent += (levelIndex) =>
            {
                _uiManager.HideCurrentPanel();
                _levelManager.LoadLevel(levelIndex);
            };
            
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

            MetaEvents.WorldsPanelButtonPressedEvent += () => { _uiManager.ShowWorldsPanel(); };

            MetaEvents.WorldButtonPressedEvent += worldIndex =>
            {
                _uiManager.ShowLevelsPanel(worldIndex);
                _lastWorldIndex = worldIndex;
            };

            MetaEvents.LastWorldButtonPressedEvent += () => { _uiManager.ShowLevelsPanel(_lastWorldIndex); };
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