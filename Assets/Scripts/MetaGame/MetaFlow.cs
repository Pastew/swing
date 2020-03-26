using MetaGame.UI;
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
            MetaEvents.PlayButtonPressedEvent += () =>
            {
                _uiManager.HideButtons();
                _uiManager.HideCurrentPanel();
                _levelManager.LoadNextLevel();
            };

            MetaEvents.ReplayButtonPressedEvent += () =>
            {
                _uiManager.HideButtons();
                _uiManager.HideCurrentPanel();
                _levelManager.LoadCurrentLevel();
            };
        }

        public void OnLevelFinished(LevelScore levelScore)
        {
            _uiManager.ShowLevelResultsScreen(levelScore);
        }
    }
}