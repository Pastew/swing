using Shared;
using UnityEngine;

namespace MetaGame
{
    public class MetaFlow : MonoBehaviour
    {
        private UIManager _uiManager;
        private LevelManager _levelManager;

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

            MetaEvents.LevelsButtonPressedEvent += () =>
            {
                _uiManager.ShowLevelsPanel();
            };

            MetaEvents.MainMenuButtonPressedEvent += () =>
            {
                _uiManager.ShowMainMenuPanel();
            };
        }

        public void OnLevelFinished(LevelScore levelScore)
        {
            _uiManager.ShowLevelResultsScreen(levelScore);
        }
    }
}